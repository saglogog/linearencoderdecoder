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
		public int[] GeneratedDecodedInfo(string info, string p){

			//arrange
			int[] iAr = GetIntArrayFromString (info);
			Decoder dec = new Decoder ();
			ShowGandHBasedOnP s = new ShowGandHBasedOnP ();
			SyndromeCreator sc = new SyndromeCreator ();
			int[,] HMatrix = s.GenerateH (p);

			ErrorWindowEventArgs ewea = null;
			ErrorEventClass eec = new ErrorEventClass ();
			Listener l = new Listener ();
			l.Subscribe (eec);

			//get the error vector
			int[] errorSyndrome = dec.CalculateErrorSyndromeForGivenCodeword (iAr, HMatrix);
			Dictionary<int[], int[]> syndromeVectorDic = sc.CreateSyndrome (HMatrix);
			int[] errorVector;
			if (!syndromeVectorDic.TryGetValue (errorSyndrome, out errorVector)) {
				ewea = new ErrorWindowEventArgs ("Ooops! Something went wrong when we tried to create" +
					" the error vector from the error syndrome");
				eec.TriggerEvent(ewea);
			}

			//correct the codeword and get the message digits from the codeword
			int[] correctCodeword = dec.CorrectCodeword (iAr, errorVector);
			int[] msg = new int[HMatrix.GetLength(1)-HMatrix.GetLength(0)];
			for (int i = 0; i < msg.Length; i++) {
				msg [i] = correctCodeword [i];
			}
				
			return msg;
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

			ShowGandHBasedOnP s = new ShowGandHBasedOnP ();

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
						"didn't you?");
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
						" different than 0 and 1");
					eec.TriggerEvent(ewea);
				}
			}

			return iAr;
		}
	}
}