using System;
using LinearEncoderDecoderLibrary;


namespace LinearEncoderDecoderInterface
{

	//delegate for the event 
	public delegate void ErrorWindowEventHandler(object sender, ErrorWindowEventArgs e);  

	public class ErrorWindowEventArgs: EventArgs{
		public readonly string _labelMessage;

		public ErrorWindowEventArgs(string labelMessage){
			_labelMessage = labelMessage;
		}

	}

	public class ShowGandHBasedOnP
	{
		public event ErrorWindowEventHandler ErrorOccured;

		public void GenerateG(string p){
			
			this.ErrorOccured += new ErrorWindowEventHandler(CreateErrorWindow);

			char[] ca = p.ToCharArray ();
			char[] ca2;

			if (ca [ca.Length - 1] != '\n') {
				ca2 = new char[ca.Length + 1];
				for (int i = 0; i < ca2.Length; i++) {
					if (ca2 [i] != ca2 [ca2.Length - 1])
						ca2 [i] = ca [i];
					else
						ca2 [i] = '\n';
				}
			} else {
				ca2= new char[ca.Length];
				ca.CopyTo (ca2, 0);
			}
			
			int[,] P;

			int j = 0;
			int h = -1;
			for (int i =0; i<ca2.Length;i++) {
				if (ca2 [i] != '\n')
					j++;
				else {
					if (h != -1 && h != j) {
						//show window with error explaining that this array doesnt have the correct format. 
						ErrorWindowEventArgs ewea = new ErrorWindowEventArgs("The P Array does not have the correct format!");
						ErrorOccured (this, ewea);
					}
					h = j;
					j = 0;
				}
			}
		}

		public void CreateErrorWindow(object sender, ErrorWindowEventArgs e){
			//add label message from eventargs property
			ErrorWindow ew = new ErrorWindow (e._labelMessage);
			ew.Show ();
		}
	}
}

