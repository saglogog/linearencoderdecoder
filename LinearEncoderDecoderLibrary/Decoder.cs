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

		/*
		public int[] CorrectCodeword(int[] erroneousCodeword, int[] errorVector){
			int[] correctCodeword = new int[errorVector.Length];


		}
		*/
	}
}

