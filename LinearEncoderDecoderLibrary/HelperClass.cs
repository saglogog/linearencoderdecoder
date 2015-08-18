using System;
using System.Collections.Generic;

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

		/// <summary>
		/// Multiply a 2 dimensional array by a vector as such: Multiply each digit of each line of the array by each digit of
		/// the vector and then get the linear combination of each line:
		///  Let there be an  array A (nxk - n is the number of lines and k is the number of columns) and a vector V (k). Then the 
		///  multiplication produces a vector S (n):
		/// 	The multiplication is acted as follows: s1 = h11xv1 + h12xv2 + ... + h1kxvk
		/// 											s2 = h21xv1 + h22xv2 + ... + h2kxvk
		/// 											.
		/// 											.
		/// 											.
		/// 											sn = hn1xv1 = hn2xv2 + ... + hnkxvk
		/// Thus we receive the vector S = [s1 s2 ... sn]
		/// </summary>
		/// <returns>A 1D vector that is returned by the afforementioned multiplication.</returns>
		/// <param name="array">Array.</param>
		/// <param name="vector">Vector.</param>
		public int[] Multiply2DArrayByVector(int[,] array, int[] vector){
			int[] resultVector = new int[array.GetLength (0)];
			for (int i = 0; i < array.GetLength (0); i++) {
				resultVector [i] = 0;
				for (int j = 0; j < array.GetLength (1); j++) {
					resultVector [i] = AddBinaries(resultVector[i], MultiplyBinaries(array[i,j],vector[j]));
				}
				if (resultVector[i] != 0 && resultVector [i] != 1)
					throw new FormatException ("The vector digits must be in binary form - they must have the value of either 1 or 0");
			}

			return resultVector;
		}

		/// <summary>
		/// Binary multiplication between two single bit binaries.
		/// </summary>
		/// <returns>Multiplication result.</returns>
		/// <param name="binary1">Binary1.</param>
		/// <param name="binary2">Binary2.</param>
		private int MultiplyBinaries(int binary1, int binary2){
			int result = 2;
			if ((binary1 != 0 && binary1 != 1) || (binary2 != 0 && binary2 != 1))
				throw new FormatException ("The arguments must be in binary form - they must have the value of either 1 or 0");
			else 
				//logical AND
				result = binary1 & binary2;

			return result;
		}

		/// <summary>
		/// Binary addition between two single bit binaries.
		/// </summary>
		/// <returns>Addition result.</returns>
		/// <param name="binary1">Binary1.</param>
		/// <param name="binary2">Binary2.</param>
		private int AddBinaries(int binary1, int binary2){
			int result = 2;
			if ((binary1 != 0 && binary1 != 1) || (binary2 != 0 && binary2 != 1))
				throw new FormatException ("The arguments must have binary form - they must have the value of either 1 or 0");
			else
				result = (binary1 + binary2) % 2;

			return result;
		}

		//use logarithm to calculate result[] digits,
		//or use list to add elements dynamically.
		private void CreateBinaryFromDecimal(double decimalNumber){
			List<int> result = new List<int> ();
			int i = 0;
			if (decimalNumber == 0)
				result.Add (0);	
			else {
				while (decimalNumber != 0) {

					//result[-i] = decimalNumber % 2;
					decimalNumber = Math.Floor (decimalNumber/2);
					i++;
				}
			}
		}


		//make private
		public int CreateDecimalFromBinary(int[] binaryNumber){
			int result = 0;
			for (int i = 0; i < binaryNumber.Length; i++) {
				if (binaryNumber [i] != 0 && binaryNumber [i] != 1) {
					throw new FormatException ();
					Console.WriteLine (i, "The digit in place {0} of the binary word array is not in binary form (0,1)");  
				}
				if (binaryNumber[i]==1)
					result +=  Math.Pow (2, (binaryNumber.Length-1)-i);
			}

			return result;
		}
		/*
		public int[] SubtractBinaries(int[] binary1, int[] binary2){
			
		}
		*/
	}
}