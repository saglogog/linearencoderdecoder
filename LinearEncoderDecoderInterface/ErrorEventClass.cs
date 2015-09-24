using System;

namespace LinearEncoderDecoderInterface
{
	public class ErrorWindowEventArgs: EventArgs{
		public readonly string _labelMessage;

		public ErrorWindowEventArgs(string labelMessage){
			_labelMessage = labelMessage;
		}

	}

	public class ErrorEventClass{
		public event ErrorWindowEventHandler ErrorOccured;
		//delegate for the event 
		public delegate void ErrorWindowEventHandler(ErrorEventClass eec, ErrorWindowEventArgs e);  
		public void TriggerEvent(ErrorWindowEventArgs ewea){
			ErrorOccured (this, ewea);
		}
	}

	public class Listener{
		public void Subscribe(ErrorEventClass eec){
			eec.ErrorOccured += new ErrorEventClass.ErrorWindowEventHandler (CreateErrorWindow);
		}
		public void CreateErrorWindow(ErrorEventClass eec, ErrorWindowEventArgs e){
			//add label message from eventargs property
			ErrorWindow ew = new ErrorWindow (e._labelMessage);
			ew.Show ();
		}
	}
}