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
	}
}

