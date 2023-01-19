using System;
using static System.Console;

namespace Movie_Collection
{
	class Program
	{
		static void Main(string[] args)
		{
			var head = ThisNode("My Neighbor Totoro");
			head.nextNode = ThisNode("Nausicaa of the Valley of the Wind");
			head.nextNode.nextNode = ThisNode("Fly Away Home");
			head.nextNode.nextNode.nextNode = ThisNode("Leon");

			WriteLine("----------------------------------------- \n" +
				  "     Command list to manage collection    \n\n" +
				  " add:  add a new movie title \n" +
				  //" search: find movie info \n" +
				  " show: show screening schedule \n" +
				  " exit:   exit program \n" +
				  "------------------------------------------");

			bool exit = false;
			while (!exit)
			{
				Write("\n Enter a command: ");
				string input = ReadLine();

				if (input == "add")
				{
					Write(" Enter a new movie title (insert after the playing title) : ");
					string data = ReadLine();
					int pos = 2;
					head = InsertNew(head, pos, data);
					WriteLine("\n--------- " + data + " has been scheduled to play after the current movie----------");
					MovieList(head);

				}
				else if (input == "show")
				{
					WriteLine("\n--------- Screening is scheduled as below ----------");
					MovieList(head);

				}
				else if (input == "exit")
				{
					exit = true;
				}
				else
				{
					WriteLine("\n Choose from a command");
				}
			}
		}

		private class Node
		{
			public string data;
			public Node nextNode;
			// insert data to the node
			public Node(string data) => this.data = data;
		}
		// create a new node
		static Node ThisNode(string data) => new Node(data);
		// insert a node to the position
		static Node InsertNew(Node headNode,
							int position, string data)
		{
			var head = headNode;
			if (position < 1)
				WriteLine("Invalid position");
			//when position=1, new node is a head node
			if (position == 1)
			{
				var newNode = new Node(data);
				newNode.nextNode = headNode;
				head = newNode;
			}
			else
			{
				while (position-- != 0)
				{
					if (position == 1)
					{
						// add node to the position
						Node newNode = ThisNode(data);
						// make new node to point to the old node
						newNode.nextNode = headNode.nextNode;
						// replace current with new node
						headNode.nextNode = newNode;
						break;
					}
					headNode = headNode.nextNode;
				}
				if (position != 1)
					WriteLine("Position is out of range!");
			}
			return head;
		}
		static void MovieList(Node node)
		{
			WriteLine("\n Now playing...\n");
			while (node != null)
			{
				Write(" " + node.data);
				node = node.nextNode;
				if (node != null)
					WriteLine("\n------------");
			}
			WriteLine();
		}

	}
}

