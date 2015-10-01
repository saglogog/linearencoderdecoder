using System;
using LinearEncoderDecoderLibrary;
using System.Collections.Generic;

namespace LinearEncoderDecoderInterface
{
	public class ShowEncodedAndDecodedInformation
	{
		
		/// <summary>
		/// Method that returns the encoded codeword from the message string given 
		/// in the interface.
		/// </summary>
		/// <returns>The encoded info (the codeword).</returns>
		/// <param name="info">String that represents the message digits.</param>
		public int[] GenerateEncodedInfo(string info){

			int[] iAr = GetIntArrayFromString(info);
			Encoder en = new Encoder ();
			 
			return en.CodewordCreator (iAr);
		}

		/// <summary>
		/// This method decodes a codeword and corrects it if it is wrong and returns the
		/// message digits.
		/// </summary>
		/// <returns>The message digits.</returns>
		/// <param name="info">The codeword to decode.</param>
		public int[] GeneratedDecodedInfo(string info, int[,] HMatrix){

			//arrange
			int[] iAr = GetIntArrayFromString (info);
			Decoder dec = new Decoder ();
			SyndromeCreator sc = new SyndromeCreator ();

			ErrorEventClass eec = new ErrorEventClass ();
			Listener l = new Listener ();
			l.Subscribe (eec);

			//get the error vector
			int[] errorSyndrome = dec.CalculateErrorSyndromeForGivenCodeword (iAr, HMatrix);
			Dictionary<int[], int[]> syndromeVectorDic = sc.CreateSyndrome (HMatrix);

			int[][] errorSyndromes = new int[HMatrix.GetLength(1)][];
			int[][] errorVectors = new int[HMatrix.GetLength(1)][];
			syndromeVectorDic.Keys.CopyTo (errorSyndromes, 0);
			syndromeVectorDic.Values.CopyTo (errorVectors,0);

			int[] temporaryErrorSyndrome = new int[HMatrix.GetLength(0)];
			int[] temporaryErrorVector = new int[HMatrix.GetLength(1)];

			for (int i = 0; i < errorSyndromes.GetLength (0); i++) {
				for (int j = 0; j < temporaryErrorSyndrome.Length; j++) {
					temporaryErrorSyndrome [j] = errorSyndromes [i] [j];
				}
					
				if (CheckArrayEquality<int>(temporaryErrorSyndrome, errorSyndrome)) {
					for (int k = 0; k < temporaryErrorVector.Length; k++) {
						temporaryErrorVector [k] = errorVectors [i] [k];
					}
				}
			}

			int[] errorVector = temporaryErrorVector;

			//correct the codeword and get the message digits from the codeword
			int[] correctCodeword = dec.CorrectCodeword (iAr, errorVector);
			int[] msg = new int[HMatrix.GetLength(1)-HMatrix.GetLength(0)];
			for (int i = 0; i < msg.Length; i++) {
				msg [i] = correctCodeword [i];
			}
				
			return correctCodeword;
		}
			

		/// <summary>
		/// This method gets a string from a button clicked method in MainWindowClass and transforms it 
		/// into an integer array to be used by the above methods, while checking for digits other than
		/// the integers 0 and 1.
		/// </summary>
		/// <returns>The int array gotten from the string.</returns>
		/// <param name="info">Information string to transform.</param>
		public int[] GetIntArrayFromString(string info){

			char[] cAr = info.ToCharArray ();

			ErrorWindowEventArgs ewea = null;
			ErrorEventClass eec = new ErrorEventClass ();
			Listener l = new Listener ();
			l.Subscribe (eec);

			//loop that populates the integer array and checks for characters other than numbers
			int[] iAr = new int[cAr.Length];
			for (int i = 0; i < cAr.Length; i++) {
				try{
					iAr[i] = (int)Char.GetNumericValue(cAr[i]);	
				}
				catch(ArgumentException e){
					ewea = new ErrorWindowEventArgs ("You entered something other than numbers, " +
						"didn't you?"+e.Message);
					eec.TriggerEvent(ewea);
				}
			}

			//loop that checks for digits other than 0 and 1
			for (int i = 0; i < iAr.Length; i++) {
				try{
					if (iAr [i] != 1 && iAr [i] != 0) {
						throw new ArgumentException();
					}
				}
				catch(ArgumentException e){
					ewea = new ErrorWindowEventArgs ("The entered information contains digits" +
						" different than 0 and 1"+e.Message);
					eec.TriggerEvent(ewea);
				}
			}

			return iAr;
		}
	
		/// <summary>
		/// Checks equality of two generic arrays.
		/// </summary>
		/// <returns><c>true</c>, if array equality was checked, <c>false</c> otherwise.</returns>
		/// <param name="a1">First array.</param>
		/// <param name="a2">Second Array.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public bool CheckArrayEquality<T>(T[] a1, T[] a2){
		
			if (ReferenceEquals (a1, a2))
				return true;
			
			if (a1 == null || a2 == null)
				return false;

			if (a1.Length != a2.Length)
				return false;

			EqualityComparer<T> comparer = EqualityComparer<T>.Default;
			for (int i = 0; i < a1.Length; i++) {
				if(!comparer.Equals(a1[i], a2[i]))
					return false;
			}

			return true;
		}	
	}
}