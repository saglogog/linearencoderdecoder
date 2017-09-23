Description
===========
This program attemts to implement linear encoding and decoding. The user provides
a matrix P and the program creates the matrices G and H. Then, if the users chooses
so, the program shows all the codewords.
The program asks of the user a word to encode a word to decode and then executes
the corresponding operations.

Some Useful terms
=================
G: 	Generator matrix with standard form G = (Ik | A)-block matrix. Its rows form a basis for a linear code. The codewords are all of the linear combinations  of the rows of this matrix(=row space of the matrix).
	G can generate codewords.
	A generator matrix for a linear [n,k,d]q code has format k x n, where n is the length of a codeword, k is the number of  information bits (dimension of C as a vector subspace), d is the minimum distance of the code and q is the number of symbols in the alphabet ( q = 2 if  the code is binary,q = 3 if the code is ternary etc.).
P: P  = A = k x r matrix, where r = n – k and r symbolizes the redundant bits of the codeword.
Ik : The k x k identity matrix.
Identity matrix : or unit matrix In of size  n is the n x n square matrix with ones on the main diagonal and zeros elsewhere.
Linear Combinations of the rows of the matrix example:
H: Check matrix (parity check matrix), H = (-At | I n – k) .
Codewords: Elements of standarized code or protocol. To generate the codewords of a code C, we need  the generator matrix G and we use the following formula: w = s G, where w is a codeword of the linear code C and s is any vector.
