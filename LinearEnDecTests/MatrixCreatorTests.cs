using NUnit.Framework;
using System;
using LinearEncoderDecoderLibrary;

namespace LinearEnDecTests
{
	[TestFixture ()]
	public class MatrixCreatorTests
	{


		[Test ()]
		public void TestGCreator ()
		{
			MockSetupClass msc = new MockSetupClass ();
			if(PropertyClass.PArray==null){
				msc.FillMatrix ();
			}
			MatrixCreator mc = new MatrixCreator ();
			int[,] GMatrix = mc.GCreator();
			Console.Write ("\n");
			for (int i = 0; i < GMatrix.GetLength(0); i++) {
				for (int k = 0; k < GMatrix.GetLength(1); k++) {
					Console.Write (GMatrix[i,k] + " ");
				}
				Console.Write ("\n");
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
			MockSetupClass msc = new MockSetupClass ();
			if(PropertyClass.PArray==null){
				msc.FillMatrix ();
			}
			MatrixCreator mc = new MatrixCreator ();
			int[,] HMatrix = mc.HCreator();
			Console.Write ("\n");
			for (int i = 0; i < HMatrix.GetLength(0); i++) {
				for (int k = 0; k < HMatrix.GetLength(1); k++) {
					Console.Write (HMatrix[i,k] + " ");
				}
				Console.Write ("\n");
			}
		}

		/*
		 * Make MatrixCreator.IdentityArrayCreator public to use.
		[Test()]
		public void TestIdentityArrayCreator(){
			MatrixCreator mc = new MatrixCreator ();
			Random rd = new Random ();
			int[,] idArray = mc.IdentityArrayCreator (rd.Next (100));
			Console.Write ("\n");
			for (int i = 0; i < idArray.GetLength(0); i++) {
				for (int k = 0; k < idArray.GetLength(1); k++) {
					Console.Write (idArray[i,k] + " ");
				}
				Console.Write ("\n");
			}
		}
		*/
	}
}