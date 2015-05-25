using System;

namespace LinearEncoderDecoderLibrary
{
	public class MatrixCreator
	{
		int[,] intPMatrix;
		int [,] IkMatrix;
		PropertyClass pc = new PropertyClass();

		/// <summary>
		/// Initializes a new instance of the <see cref="LinearEncoderDecoderLibrary.MatrixCreator"/> class.
		/// </summary>
		/// <param name="P">The user given matrix P</param>
		public MatrixCreator()
		{
			intPMatrix = pc.PArray;
		}
			
		private int[,] IdentityArrayCreator(int k){
			int[,] identityArray = new int[k, k];
			for (int i = 0; i < k; i++) {
				identityArray [i, i] = 1;
			}
			return identityArray;
		}

		//G = [Ik|P]
		public int[,] GCreator(){
			IkMatrix = IdentityArrayCreator (intPMatrix.GetLength (0));
			int[,] GMatrix = new int[intPMatrix.GetLength (0), intPMatrix.GetLength (0) + intPMatrix.GetLength (1)];
			try{
				for (int k = 0; k < intPMatrix.GetLength (0); k++) {
					for (int n = 0; n < intPMatrix.GetLength (0) + intPMatrix.GetLength (1); n++) {
						//when n>tis statheris posotitas=arithmos grammwn(rows) tou P)
						if (n >= intPMatrix.GetLength(0)) {
							// G[k,n] = P[k,n-(n-k)], the n portion varies while the n-k is stable in P 
							GMatrix [k, n] = intPMatrix [k, n - ((intPMatrix.GetLength (0) + intPMatrix.GetLength (1)) - intPMatrix.GetLength (0)-1)];
						} else {
							GMatrix [k, n] = IkMatrix [k, n];
						}
					}
				}
			}
			catch(IndexOutOfRangeException e){
				Console.Write(e.StackTrace );
			}
			return GMatrix;
		}

		private int[,] MatrixTransposer(int[,] matrixRegular){
			int[,] matrixTranspose = new int[matrixRegular.GetLength (1), matrixRegular.GetLength (0)];
			for (int i = 0; i < matrixRegular.GetLength (0); i++) {
				for (int j = 0; j < matrixRegular.GetLength (1); j++) {
					matrixTranspose [j, i] = matrixRegular [i, j];
				}
			}
			return matrixTranspose;
		}

		//H = [Ptrasnpose|In-k]
		public int[,] HCreator(){
			//IkMatrix = In-k
			IkMatrix = IdentityArrayCreator ((intPMatrix.GetLength (0) + intPMatrix.GetLength (1)) - intPMatrix.GetLength (0));
			//Ptranspose
			int[,] pt = MatrixTransposer(intPMatrix);
			//n-k rows , n columns( n-k from In-k and k from Ptranspose)
			int[,] HMatrix = new int[(intPMatrix.GetLength (0) + intPMatrix.GetLength (1)) - intPMatrix.GetLength (0), intPMatrix.GetLength (0) + intPMatrix.GetLength (1)];
			try{
				for (int i = 0; i < (intPMatrix.GetLength (0) + intPMatrix.GetLength (1)) - intPMatrix.GetLength (0); i++) {
					for (int j = 0; j < intPMatrix.GetLength (0) + intPMatrix.GetLength (1); j++) {
						//PMatrix.GetLength(0) = k = Ptranspose columns
						if (j >= intPMatrix.GetLength (0)) {
							//same as in G matrix as to length twn columns tis IkMatrix = n-k kai to length olwn twn columns einai = n 
							HMatrix[i,j]=IkMatrix[i,j-((intPMatrix.GetLength (0) + intPMatrix.GetLength (1)) - intPMatrix.GetLength (0)-1)];
						} else {
							HMatrix [i, j] = pt [i, j];
						}
					}
				}
			}
			catch(IndexOutOfRangeException e){
				Console.Write(e.StackTrace );
			}
			return HMatrix;
		}

		public int[,] ReturnPMatrix(){
			int[,] thePMatix = intPMatrix;
			return thePMatix;
		}
	}
}

