namespace Course.MN.Users
{
	public class Dog
	{
		public string Name { get; set; } 
		public string[] Owners { get; set; }
		public string Breed { get; set; }
		public Gender Gender { get; set; }
	}

	public enum Gender
	{
		Male,
		Female,
		Other,
		RefusedToSay,
		ConfusedAboutIt
	}
}