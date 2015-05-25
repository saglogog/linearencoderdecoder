using NUnit.Framework;
using System;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class MatrixCreatorTests
	{
		MatrixCreator mc;
		string[,] matrix;
		public MatrixCreatorTests(){
			matrix = matrixFiller ();
			PropertyClass pc = new PropertyClass ();
			pc.PArray = 
			mc = new MatrixCreator(matrix);
		}
		Random rd = new Random ();
		public string[,] matrixFiller(){
			string[,] theMatrix = new string[3, 4];
			for (int i = 0; i < 3; i++) {
				for (int k = 0; k < 4; k++) {
					theMatrix [i, k] = Convert.ToString(rd.Next ()%2);
				}
			}
			return theMatrix;
		}


		[Test ()]
		public void TestGCreator ()
		{
			int[,] GMatrix = mc.GCreator();
			for (int i = 0; i < 3; i++) {
				for (int k = 0; k < 7; k++) {
					Console.Write (GMatrix[i,k] + " ");
					if (k == 6) {
						Console.Write ("\n");
					}
				}
			}
		}
		/*
		[Test ()]
		public void TestCase2(){
			int[,] GMatrix = mc.GCreator();
			int[,] matrixTranspose = mc.MatrixTransposer (GMatrix);
			for (int i = 0; i < GMatrix.GetLength (0); i++) {
				for (int j = 0; j < GMatrix.GetLength (1); j++) {
					Console.Write (GMatrix [i, j] + " ");
					if (j == GMatrix.GetLength (1) - 1) {
						Console.Write ("\n");
					}
				}
			}
			for (int i = 0; i < GMatrix.GetLength (1); i++) {
				for (int j = 0; j < GMatrix.GetLength (0); j++) {
					Console.Write (matrixTranspose [i, j] + " ");
					if (j == GMatrix.GetLength (0) - 1) {
						Console.Write ("\n");
					}		
				}
			}
		}
		*/
		[Test ()]
		public void TestHCreator ()
		{
			int[,] HMatrix = mc.HCreator();
			for (int i = 0; i < 4; i++) {
				for (int k = 0; k < 7; k++) {
					Console.Write (HMatrix[i,k] + " ");
					if (k == 6) {
						Console.Write ("\n");
					}
				}
			}
		}
	}
}