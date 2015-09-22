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
		/// <returns>The matrix.</returns>
		public  int[,] FillMatrix(){
			Random rd = new Random ();
			//--PropertyClass pc = new PropertyClass ();
			int[,] theMatrix = new int[rd.Next(100), rd.Next(100)];
			for (int i = 0; i < theMatrix.GetLength(0); i++) {
				for (int k = 0; k < theMatrix.GetLength(1); k++) {
					theMatrix [i, k] = rd.Next ()%2;
				}
			}
			//--pc.PArray = theMatrix;
			PropertyClass.PArray = theMatrix;
			return theMatrix;
		}
	}
}