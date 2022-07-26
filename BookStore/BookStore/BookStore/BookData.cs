using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore {
	public class BookData {
		public Book[] books;
	}
	public class Book {
		public string Title { get; set; }
		public string Subitle { get; set; }
		public string ISBN13 { get; set; }
		public string Price { get; set; }
		public string Image { get; set; }
		public string URL { get; set; }
		public override string ToString() {
			return string.Format("{0} ({1})", Title, ISBN13);
		}
	}
}
