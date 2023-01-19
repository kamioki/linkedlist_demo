using System;
using static System.Console;

namespace Customer_Collection
{
	public class Linkedlist
	{
		public class Node
		{
			public Customer customer;
			public Node prev, next;
			public string data;
			public Node(string nodedata)
			{
				data = nodedata;
			}
			public Node(Customer customer, Node prev, Node next)
			{
				this.customer = customer;
				this.prev = prev;
				this.next = next;
			}
		}
		public static void Main(String[] args)
		{
			Node head = null;// make empty list
			Linkedlist Collection = new Linkedlist();

			WriteLine("----------------------------------------- \n" +
				  "     Command list to manage collection    \n\n" +
				  " add:    add customer info \n" +
				  //" search: find customer info \n" +
				  " delete: delete customer info \n" +
				  " exit:   exit program \n" +
				  "------------------------------------------");

			bool exit = false;
			while (!exit)
			{
				Write("\n Enter a command: ");
				string input = ReadLine();

				if (input == "add")
				{
					Write(" Enter name to add: ");
					string name = ReadLine();
					head = add(head, name);
					WriteLine("\n--------- "+ name +" was added to the list----------");
					customerList(head);

					//WriteLine("Enter phone number: ");
					//string mobile = ReadLine();
					//
					//WriteLine("Pay by 'cash' or 'card' ?: ");
					//string payment = ReadLine();
				}
				else if (input == "delete")
				{
					Write(" Enter name to delete: ");
					string deletename = ReadLine();
					head = deleteMatch(head, deletename);
					WriteLine("\n--------- " + deletename + " was deleted from the list----------");
					customerList(head);
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

		public static Node deleteNode(Node head, Node delete)
		{// base case
			if (head == null || delete == null) 
				return null;
			 //If head node will be deleted
			if (head == delete)
				head = delete.next;
			//Change next only when deleting node is not the last node
			if (delete.next != null) 
				delete.next.prev = delete.prev;
			//Change prev only when deleting node is not the first node
			if (delete.prev != null) 
				delete.prev.next = delete.next;

			delete = null;
			return head;
		}

		public static Node deleteMatch(Node head, string matchdata)
		{
			//if the list is empty
			if (head == null)
				return null;

			Node current = head;
			Node next;
			//traverse the list up to the end
			while (current != null)
			{
				// if found a matched data
				if (current.data == matchdata)
				{
					//save next node in the pointer next
					next = current.next;
					//delete node pointed to current
					head = deleteNode(head, current);
					//refresh current to next
					current = next;
				}
				//move to the next node
				else
					current = current.next;
			}
			return head;
		}
		//insert node to the head
		public static Node add(Node head, string new_data)
		{
			//create new node
			Node newNode = new Node(new_data);
			//put new data to node
			newNode.data = new_data;
			//prev in head is null
			newNode.prev = null;
			//connect the old node to the new node
			newNode.next = head;
			//change prev head to the new node
			if (head != null)
			head.prev = newNode;
			//change the head to new node
			head = newNode;

			return head;
		}


		static void customerList(Node temp)
		{
			if (temp == null)
				Write("\n Customer list is empty!");
			while (temp != null)
			{
				Write(temp.data + "\n");
				temp = temp.next;
			}
		}

		public class Customer //gather customer information
		{
			private string name;
			private string mobile;
			private string payment;
			private int visits;

			public string CustomerName
			{
				get { return name; }
			}

			public string MobileNum
			{
				get { return mobile; }
			}

			public string PaymentMethod
			{
				get { return payment; }
			}

			public int VisitNum
			{
				get; set;
			}
			public void CountVisits()
			{
				visits++;
			}
			public Customer(string name, string mobileNumber, string paymentMethod)
			{
				this.name = name;
				this.mobile = mobileNumber;
				this.payment = paymentMethod;
				this.visits = 9;
			}

			public override string ToString()
			{
				return (name + " " + mobile + payment + visits.ToString() + "\n");
			}

		}


	}
}
