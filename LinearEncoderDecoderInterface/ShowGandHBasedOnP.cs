using System;
using LinearEncoderDecoderLibrary;


namespace LinearEncoderDecoderInterface
{

	public class ShowGandHBasedOnP
	{
		
		public int[,] ReturnPArray(string p){

			char[] ca = p.ToCharArray ();
			char[] ca2;

			if (ca [ca.Length - 1] != '\n') {
				ca2 = new char[ca.Length + 1];
				ca.CopyTo (ca2, 0);
				ca2 [ca2.Length - 1] = '\n';
			} else {
				ca2 = new char[ca.Length];
				ca.CopyTo (ca2, 0);
			}

			int j = 0;
			int h = -1;
			ErrorWindowEventArgs ewea = null;
			ErrorEventClass eec = new ErrorEventClass ();
			Listener l = new Listener ();
			l.Subscribe (eec);
			for (int i = 0; i < ca2.Length; i++) {
				if (ca2 [i] != '\n')
					j++;
				else {
					if (h != -1 && h != j && ewea == null) {
						//show window with error explaining that this array doesnt have the correct format. 
						ewea = new ErrorWindowEventArgs ("The P Array does not have the correct format!");
						eec.TriggerEvent (ewea);
					}
					h = j;
					j = 0;
				}
			}
				
			HelperClass hc = new HelperClass ();
			int[,] P = null;
			try{
				P = hc.ConvertCharArrayTo2DIntArray (ca2, '\n');
			}
			catch(ArgumentException e){
				ErrorWindowEventArgs ewea2 = new ErrorWindowEventArgs ("Some of the P array arguments are not 0s or 1s !");
				eec.TriggerEvent (ewea2);
			}
				
			return P;
		}

		public int[,] GenerateG(string p){

			PropertyClass.PArray = ReturnPArray (p);

			MatrixCreator mc = new MatrixCreator ();

			return mc.GCreator ();
		}

		public int[,] GenerateH(string p){

			PropertyClass.PArray = ReturnPArray (p);			

			MatrixCreator mc = new MatrixCreator ();

			return mc.HCreator ();
		}
						
	}
}