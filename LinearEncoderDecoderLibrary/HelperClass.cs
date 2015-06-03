using System;

namespace LinearEncoderDecoderLibrary
{
	public class HelperClass
	{
		/// <summary>
		/// Converts
		/// </summary>
		/// <returns>The dim array converter.</returns>
		/// <param name="matrix">Matrix.</param>
		public int[,] TwoDimArrayConverter(string[,] matrix)
		{
			int[,] twoDimArray = new int[matrix.GetLength(0),matrix.GetLength(1)];
			for (int i = 0; i < matrix.GetLength(0); i++) {
				for (int k = 0; k < matrix.GetLength (1); k++) {
					twoDimArray [i,k] = Convert.ToInt32 (matrix [i,k]);
				}
			}
			return twoDimArray;
		}
			
	}
}

