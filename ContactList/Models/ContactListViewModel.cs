namespace ContactList.Models
{
	public class ContactListViewModel
	{

		public ContactListViewModel(IEnumerable<Contact> ContactList)
		{
			Item = new Contact();
			Contacts = ContactList;
			Favourites = true;
			Active = true;
		}
		public ContactListViewModel()
		{
			Item = new Contact();	
			Contacts = new List<Contact>();
			Favourites = true;
			Active = true;	
		}

		public bool Favourites { get; set; }

		public bool Active { get; set; }
		//easier to get display name for the view
		public Contact Item { get; set; }

		public IEnumerable<Contact> Contacts { get; set; }
	}
}
