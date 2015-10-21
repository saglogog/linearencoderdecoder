using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearEncoderDecoderLibrary
{
	public class SyndromesAndCosetLeaders
	{
		readonly int[,] codewords;
		int numberOfCodewords;
		int lengthOfCodewords;

		public SyndromesAndCosetLeaders(int [,] _codewords){
			codewords = _codewords;
			numberOfCodewords = codewords.GetLength (0);
			lengthOfCodewords = codewords.GetLength (1);
		}

		public int[,] ReturnCosetLeaders(){

			List<int[]> cosetLeadersUsedSoFar = new List<int[]> ();

			HelperClass hc = new HelperClass ();

			// number of codewords = k
			double numberOfCosetLeaders = Math.Pow(2, (double)(codewords.GetLength(1) - Math.Log((double)codewords.GetLength(0), 2))); 

			CodewordGenerator cg = new CodewordGenerator (lengthOfCodewords);
			int[,] allBinaries = cg.CreateAllBinaryMsgWords ();
			int[][] binaries = new int[allBinaries.GetLength (0)][];
			binaries = hc.ConvertRectangulartoJaggedLtoA(allBinaries); 
			int[] numbersOfOnes = CheckForOnesInRectangularArrayOfBinaries (allBinaries);

			//creates a relationship between the number of ones and their binaries 
			Dictionary<int[], int> dic = new Dictionary<int[], int>();
			for (int j = 0; j < numbersOfOnes.Length; j++) {
				dic.Add(binaries[j], numbersOfOnes[j]);
			}

			int counter = 0;
			int[] currentCosetLeader = new int[lengthOfCodewords];
			for (int i = 0; i < (int)numberOfCosetLeaders; i++) {

				for (int j = 0; j < lengthOfCodewords; j++) {
					currentCosetLeader[j] = allBinaries [counter, j];
				}
					
				if (counter != 0 && counter <= allBinaries.GetLength (0)) {
					counter *= 2;
				} else if (counter == 0) {
					counter = 1;
				} else {
					//how many ones I need the cosets to have 
					//starts from two b/c all the ones have been used
					int value = 2;

					for(int k = 0; k <(int)numberOfCosetLeaders;k++){
						if (dic.FirstOrDefault(x => x.Value == value).Value == 2){
							
						}
					}
				}

				cosetLeadersUsedSoFar.Add (currentCosetLeader);
			}

			return allBinaries;
		}

		/// <summary>
		/// Returns the number of ones in a binary.
		/// </summary>
		/// <returns>An integer that signifies the number of ones in the given binary number.</returns>
		/// <param name="binary">The binary number given as an array, where each element represents a digit.</param>
		public int ReturnNumberOfOnesInBinary(int[] binary){
			int numberOfOnes = 0;

			for (int i = 0; i < binary.Length; i++) {
				if (binary [i] == 1)
					numberOfOnes++;
			}

			return numberOfOnes;
		}

		/// <summary>
		/// Finds how many ones exist in each binary of a two dimensional array.
		/// </summary>
		/// <returns>An array in which each entry represents the number of ones in the corresponding binary in the 2d binary array.</returns>
		/// <param name="binaries">The 2d binaries array.</param>
		public int[] CheckForOnesInRectangularArrayOfBinaries(int[,] binaries){
			
			int[] currentBinary = new int[binaries.GetLength(1)];
			int[] onesCounter = new int[binaries.GetLength(0)];

			for (int i = 0; i < binaries.GetLength (0); i++) {
				for (int j = 0; j < binaries.GetLength (1); j++) {
					currentBinary [j] = binaries [i, j];
				}
				onesCounter [i] = ReturnNumberOfOnesInBinary (currentBinary);
			}

			return onesCounter;
		}

		/// <summary>
		/// Checks if the given coset already exists in the standard array.
		/// </summary>
		/// <returns><c>true</c>, if if coset exists was checked, <c>false</c> otherwise.</returns>
		/// <param name="cosetLeadersAlreadyUsed">Coset leaders already used.</param>
		/// <param name="cosetToCheck">Coset to check.</param>
		public bool CheckIfCosetExists (List<int[]> cosetLeadersAlreadyUsed, int[] cosetToCheck){
			int[][] cosetLeadersArray = new int[cosetLeadersAlreadyUsed.Count][];
			cosetLeadersAlreadyUsed.CopyTo (cosetLeadersArray);
			int[][] rowOfCosets = new int[numberOfCodewords][];

			bool innerCounter1 = false;
			bool innerCounter2 = false;
			bool outerCounter = false;
			for (int h = 0; h < cosetLeadersAlreadyUsed.Count; h++) {
				rowOfCosets = GetARowOfCosets(cosetLeadersArray[h]);
				for (int l = 0; l < numberOfCodewords; l++) {
					for (int m = 0; m < lengthOfCodewords; m++) {
							if (cosetToCheck [m] == cosetLeadersArray [l] [m])
								innerCounter1 = true;
							else
								innerCounter1 = false;
							if (innerCounter1)
								innerCounter2 = true;
							else
								innerCounter2 = false;
					}
					if (innerCounter2) {
						outerCounter = true;
						break;
					}
				}
			}

			//			bool innerCounter1 = false;
			//			bool innerCounter2 = false;
			//			bool outerCounter = false;
			//			for (int i = 0; i < cosetLeadersArray; i++) {
			//				for (int j = 0; j < lengthOfCodewords; j++) {
			//					if (cosetToCheck [j] == cosetLeadersArray [i] [j])
			//						innerCounter1 = true;
			//					else
			//						innerCounter1 = false;
			//					
			//					if (innerCounter1)
			//						innerCounter2 = true;
			//					else
			//						innerCounter2 = false;
			//				}
			//				if (innerCounter2) {
			//					outerCounter = true;
			//					break;
			//				}
			//			}

			return outerCounter;
		}


		/// <summary>
		/// Gets A row of cosets by adding the coset leader to each codeword.
		/// </summary>
		/// <returns>The A row of cosets.</returns>
		/// <param name="cosetLeader">Coset leader.</param>
		public int[][] GetARowOfCosets(int[] cosetLeader){
			
			int[][] cosetsRow = new int[numberOfCodewords][];
			HelperClass hc = new HelperClass ();
			int[][] arrayOfCodewords = hc.ConvertRectangulartoJaggedLtoA (codewords);


			for (int i = 0; i < numberOfCodewords; i++) {
				cosetsRow[i] = addBinariesMod2(arrayOfCodewords[i], cosetLeader); 	
			}

			return cosetsRow;
		}


		/// <summary>
		/// Adds the binaries mod2 (equivalent to XOR bit-wise addition according to wikipedia).
		/// </summary>
		/// <returns>The binaries added mod2.</returns>
		/// <param name="binary1">Binary1.</param>
		/// <param name="binary2">Binary2.</param>
		public int[] addBinariesMod2(int[] binary1, int[] binary2){
			if (binary1.Length != binary2.Length)
				throw new ArgumentException ("The binary arguments do not have the same length.");
			HelperClass hc = new HelperClass ();
			int[] binary3 = new int[binary1.Length];
			for (int i = 0; i < binary1.Length; i++) {
				binary3[i] = hc.AddBinaries (binary1 [i], binary2 [i]);
			}

			return binary3;
		}
			
	}
}