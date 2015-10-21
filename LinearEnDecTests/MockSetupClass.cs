using System;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	public class MockSetupClass
	{
		/// <summary>
		/// Fills the pArray property in the property class.
		/// It also returns the matrix for testing purposes. 
		/// </summary>
		/// <returns>The p array.</returns>
		public  int[,] FillMatrix(){
			Random rd = new Random ();
			//--PropertyClass pc = new PropertyClass ();
			int[,] theMatrix = new int[rd.Next(10), rd.Next(10)];
			for (int i = 0; i < theMatrix.GetLength(0); i++) {
				for (int k = 0; k < theMatrix.GetLength(1); k++) {
					theMatrix [i, k] = rd.Next ()%2;
				}
			}
			//--pc.PArray = theMatrix;
			PropertyClass.PArray = theMatrix;
			return theMatrix;
		}

		/// <summary>
		/// Provides a multidimensional array of codewords for testing purposes,
		/// based on the data provided by the FillMatrix() method.
		/// </summary>
		/// <returns>The codewords array.</returns>
		public int[,] ProvideCodewords(){
			FillMatrix ();
			int n = PropertyClass.PArray.GetLength(0) + PropertyClass.PArray.GetLength(1);
			int k = PropertyClass.PArray.GetLength (0);
			CodewordGenerator cg = new CodewordGenerator (k);
			int[,] codewords = cg.CreateAllCodewordsBasedOnKAndP (n);

			return codewords;
		}

		/// <summary>
		/// Returns a random binary (an integer array of 0s and 1s).
		/// </summary>
		/// <returns>An integer array of 0s and 1s.</returns>
		/// <param name="binaryLength">The length of the array containing the binary.</param>
		public int[] GetARandomBinary(int binaryLength){
			int[] rdBinary = new int[binaryLength];
			Random rd = new Random ();
			for (int i = 0; i < binaryLength; i++) {
				rdBinary [i] = rd.Next () % 2;
			}

			return rdBinary;
		}


		/// <summary>
		/// Prints an array to the console. 
		/// </summary>
		/// <param name="message1">The message to write before the array.</param>
		/// <param name="array">Array.</param>
		public void PrintAnArray(string message1, int[] array){
			Console.WriteLine (message1);
			for (int i = 0; i < array.Length; i++) {
				Console.Write (array [i] + " ");
			}
			Console.WriteLine ();
		}

		/// <summary>
		/// Prints a 2D array ot the console.
		/// </summary>
		/// <param name="message1">Message1.</param>
		/// <param name="array">Array.</param>
		public void Print2DArray(string message1, int[,] array){
			Console.WriteLine (message1);
			for (int i = 0; i < array.GetLength (0); i++) {
				for (int j = 0; j < array.GetLength (1); j++) {
					Console.Write(array[i,j]);
				}
				Console.WriteLine ();
			}
			Console.WriteLine ();
		}


		/// <summary>
		/// Prints a jagged array to the console.
		/// </summary>
		/// <param name="message1">Message1.</param>
		/// <param name="array">Array.</param>
		public void PrintJaggedArray(string message1, int[][]array){
			Console.WriteLine (message1);
			for (int i = 0; i < array.Length; i++) {
				for (int j = 0; j < array[i].Length; j++) {
					Console.Write(array[i][j]);
				}
				Console.WriteLine ();
			}
			Console.WriteLine ();
		}
	}
}