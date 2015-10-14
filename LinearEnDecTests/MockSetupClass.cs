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
	}
}