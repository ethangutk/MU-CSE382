using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace Messaging {
	public class Producer {
		private string name;
		private int id1;
		private int id2;
		public Producer(string name) {
			this.name = name;
			id1 = 0;
			id2 = 0;
		}
		public void Trigger1() {
			Console.WriteLine(name + " sending message type #1 " + ++id1);
			MessagingCenter.Send<Producer, int>(this, "Event1", id1);
		}
		public void Trigger2() {
			Console.WriteLine(name + " sending message type #2 " + ++id2);
			MessagingCenter.Send<Producer, int>(this, "Event2", id2);
		}
		public override string ToString() {
			return name;
		} 
	}
	public class Receiver {
		public string name;
		public Receiver(string n) {
			name = n;
			MessagingCenter.Subscribe<Producer, int>(this, "Event1", (sender, arg) => {
				Console.WriteLine(name + " received message " + arg + " from " + sender.ToString());
				//Thread.Sleep(10000);   // this causes the Producer's to stall
			});
		}
	}
	public class Program {
		public static void Main(String [] args) {
			Producer P1 = new Producer("P1");
			Receiver R1 = new Receiver("R1");
			Producer p1 = new Producer("p1");
			Receiver r1 = new Receiver("r1");

			Producer p2 = new Producer("p2");
			Receiver r2 = new Receiver("r2");

			p1.Trigger1();
			p2.Trigger1();
/*
			P1.Trigger1();
			// P1 sending message type #1 1
			// R1 received message 1 from P1

			P1.Trigger1();
			// P1 sending message type #1 2
			// R1 received message 2 from P1
			Receiver B = new Receiver("R2");

			P1.Trigger1();
			// P1 sending message type #1 3
			// R1 received message 3 from P1
			// R2 received message 3 from P1

			P1.Trigger2();
			// P1 sending message type #2 1
*/
		}
	}
}
