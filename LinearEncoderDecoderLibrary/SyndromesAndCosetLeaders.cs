using System;

namespace LinearEncoderDecoderLibrary
{
	public class SyndromesAndCosetLeaders
	{
		readonly int[,] _codewords;

		public SyndromesAndCosetLeaders(int [,] codewords){
			_codewords = codewords;
		}

		public int[,] ReturnCosetLeaders(){

			int[,] cosetleaders;

			// codeword length = n
			int codewordLength = _codewords.GetLength (1);

			// number of codewords = k
			double numberOfCodewords = Math.Pow(2, (double)(_codewords.GetLength(1) - Math.Log((double)_codewords.GetLength(0), 2))); 

			CodewordGenerator cg = new CodewordGenerator (codewordLength);
			int[,] allBinaries = cg.CreateAllBinaryMsgWords ();

			int counter = 0;
			for (int i = 0; i < (int)numberOfCodewords; i++) {

				for (int j = 0; j < codewordLength; j++) {
					cosetleaders [i, j] = allBinaries [counter, j];
				}

				if (counter != 0 && counter <= allBinaries.GetLength (0)) {
					counter *= 2;
				} else if (counter == 0) {
					counter = 1;
				} else {
					
				}
			}

			return allBinaries;
		}

		/// <summary>
		/// Returns the number of ones in a binary.
		/// </summary>
		/// <returns>An integer that signifies the number of ones in the given binary number.</returns>
		/// <param name="binary">The binary number given as an array, where each element represents a digit.</param>
		private int ReturnNumberOfOnesInBinary(int[] binary){
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
		public int[] CheckForOnes(int[,] binaries){
			
			int[] currentBinary = null;
			int[] onesCounter = null;

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
		public bool CheckIfCosetExists (int[,] cosetLeadersAlreadyUsed, int[] cosetToCheck){
			
		}

	}
}

