using System;

namespace LinearEncoderDecoderLibrary
{
	public class Decoder
	{
		
		/// <summary>
		/// Calculates the error syndrome for a given codeword. The tests for this method woult be the same as for the
		/// HelperClass.Multiply2DArrayVector() .
		/// </summary>
		/// <returns>The error syndrome for the given codeword.</returns>
		/// <param name="codeword">A codeword.</param>
		/// <param name="HMatrix">H matrix.</param>
		public int[] CalculateErrorSyndromeForGivenCodeword(int[] codeword, int[,] HMatrix){
			HelperClass hc = new HelperClass ();

			int[] errorSyndrome = hc.Multiply2DArrayByVector (HMatrix, codeword);

			return errorSyndrome;
		}

		/// <summary>
		/// Corrects the codeword, by subtracting the corresponding error vector from the discovered wrong codeword.
		/// It uses the helper classes SubtractBinaries() and adds 0 if the correct codeword is smaller in digits than
		/// the rest of the codewords.
		/// </summary>
		/// <returns>The correct codeword.</returns>
		/// <param name="erroneousCodeword">Erroneous codeword.</param>
		/// <param name="errorVector">Error vector.</param>
		public int[] CorrectCodeword(int[] erroneousCodeword, int[] errorVector){
			HelperClass hc = new HelperClass ();
			int[] correctCodeword2;

			int[] correctCodeword = hc.SubtractBinaries (erroneousCodeword, errorVector);

			if (correctCodeword.Length < errorVector.Length) {
				correctCodeword2 = new int[errorVector.Length];
				for (int i = 0; i < errorVector.Length - correctCodeword.Length; i++) {
					correctCodeword2 [(errorVector.Length-1) - i] = 0;
				}
				for (int i = 0; i < correctCodeword.Length; i++) {
					correctCodeword2 [(correctCodeword.Length-1) - i] = correctCodeword [(correctCodeword.Length-1) - i];
				}
			} else
				correctCodeword2 = correctCodeword;
			
			correctCodeword2 = hc.ReverseIntArray (correctCodeword2);

			return correctCodeword2;
		}

	}
}

