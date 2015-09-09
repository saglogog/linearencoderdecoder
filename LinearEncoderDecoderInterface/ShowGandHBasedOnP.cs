using System;
using LinearEncoderDecoderLibrary;


namespace LinearEncoderDecoderInterface
{
	//delegate for the event 
	public delegate void ErrorWindowEventHandler(object sender, EventArgs e);  

	public class ErrorWindowEventArgs: EventArgs{
		public readonly string _labelMessage;

		public ErrorWindowEventArgs(string labelMessage){
			_labelMessage = labelMessage;
		}
	
	}

	public class ShowGandHBasedOnP
	{
		
		public event ErrorWindowEventHandler ErrorOccured;

		protected virtual void OnErrorOccured(EventArgs e){
			ErrorOccured (this, e);
		}

		public void GenerateG(string p){
			char[] ca = p.ToCharArray ();
			int[,] P;
			int j = 0;
			int h = -1;
			ErrorWindowEventArgs e = new ErrorWindowEventArgs ("The number of lines do not match the number of columns");
			for (int i =0; i<ca.Length;i++) {
				if (ca [i] != '\n')
					j++;
				else {
					if (h != -1 && h != j) {
						//show window with error explaining that this array doesnt have the correct format. 
						OnErrorOccured(e);
					}
					h = j;
					j = 0;
				}
			}
		}
	}
}

