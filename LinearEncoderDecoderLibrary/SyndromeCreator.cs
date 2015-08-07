using System;
using System.Collections.Generic;

namespace LinearEncoderDecoderLibrary
{
	/// <summary>
	/// This class is where the pinakas dianusmatwn lathous is created when first needed and the correct codeword
	/// from an error vector calculated. 
	/// </summary>
	public class SyndromeCreator
	{

		public int[,] CreateErrorVectors(int n){
			//Each error vector has n digits. In all we use n+1 error vectors.
			int[,] errorVectors = new int[n + 1, n];

			//The problem: We need to get all the possible error vectors with n digit length that each contain one or no ones,
			//ex. : for n = 3, we have the error vectors: 000, 001, 010, 100.
			//The following logic works as follows: We have two loops, one that iterates over the lines of the array(outer)
			//and one that iterates over the columns(inner). The inner loop checks whether the column number matches the line number and if 
			//it gives the digit the value one(1) instead of zero(0) as it would normally do.
			//ie in an array A(3,2) the a11, and a22 digits will get the value 1 so that the array looks like this: 
			// 10
			// 01
			// 00
			for (int i = 0; i < n + 1; i++) {
				for (int j = 0; j < n; j++) {
					if (j == i)
						errorVectors [i, j] = 1;
					else
						errorVectors [i, j] = 0;
				}
			}

			return errorVectors;
		}

		//magic follows(check the notes): since our error vectors only contain up to one  1 and knowing exactly how the error 
		//vectors are produced(ex: 100,010,001,000) we execute the multiplication between the HMatrix and the error vectors 
		//array as follows: the error syndrome of each vector is the column of the Hmatrix where the 1 is in the
		//corresponding codeword so knowing how that in the first vector the one is the first digit, in the second
		// the one is in the second digit etc we get as the first syndrome the first column of H, the second syndrome is
		// the second etc. In the case of the 00...0 error vector the syndrome is 000.

		public Dictionary<int[], int []> CreateSyndrome(int n, int[,] HMatrix){
			
			Dictionary<int[], int[]> syndromeAndErrorVectorArray = new Dictionary<int[], int[]> ();
			HelperClass hc = new HelperClass ();
			//Get the error vectors array based on n and then convert ot jagged from multidimensional
			int[][] errorVectors = hc.ConvertRectangulartoJaggedLtoA(CreateErrorVectors (n));
			int[][] syndromes = hc.ConvertRectangulartoJaggedCtoA (HMatrix);

			for (int i = 0; i < n ; i++) {
				syndromeAndErrorVectorArray.Add (syndromes [i], errorVectors [i]);
			}

			return syndromeAndErrorVectorArray;
		}


		/*
		public Dictionary<int[], int[]>  CreateSyndrome(int n, int[,]HMatrix){
			Dictionary<int[], int[]> syndromeAndErrorVectorArray = new Dictionary<int[], int[]> ();
			int[,] errorVectors = CreateErrorVectors (n);
			int[] currentErrorVector = new int[n];
			int[] currentErrorSyndrome = new int[n];
				for (int i = 0; i < n + 1; i++) {
					for (int j = 0; j <= HMatrix.GetLength(0); j++) {
						for(int l =0; l<=n; l++){
							
						}
					}

				}
					return syndromeAndErrorVectorArray;
		}
		*/
	}
}

