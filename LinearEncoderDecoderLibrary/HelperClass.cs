using System;

namespace LinearEncoderDecoderLibrary
{
	public class HelperClass
	{
		/// <summary>
		/// Converts a two dimensional string array to a two dimensional int array.
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

		/// <summary>
		/// Converts an int, two-dimensional rectangular array to a jagged array(lines of rectangular become arrays(LtoL)).
		/// </summary>
		/// <returns>The jagged array.</returns>
		/// <param name="rectangular">The rectangular array.</param>
		public int[][] ConvertRectangulartoJaggedLtoA(int[,] rectangular){
			int[][] jagged = new int[rectangular.GetLength (0)][];
			for (int i = 0; i < rectangular.GetLength (0); i++) {
				jagged[i] =new int[rectangular.GetLength(1)];
				for (int j = 0; j < rectangular.GetLength (1); j++) {
					jagged [i] [j] = rectangular [i, j];
				}
			}
			return jagged;
		}

		/// <summary>
		/// Converts an int, two-dimensional rectangular array to a jagged array(columns of rectangular become arrays(LtoL)).
		/// </summary>
		/// <returns>The jagged array.</returns>
		/// <param name="rectangular">Rectangular array.</param>
		public int[][] ConvertRectangulartoJaggedCtoA(int[,] rectangular){
			int[][] jagged = new int[rectangular.GetLength(1)][];
			for (int j = 0; j < rectangular.GetLength (1); j++) {
				jagged [j] = new int[rectangular.GetLength (0)];
				for (int i = 0; i < rectangular.GetLength (0); i++) {
					jagged [j] [i] = rectangular [i, j];
				}
			}
			return jagged;
		}
	}
}