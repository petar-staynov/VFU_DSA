using System;
using System.Linq;

namespace Friends
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of people");
            int numOfPeople = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of friendships");
            int numOfFriendships = int.Parse(Console.ReadLine());

            //int[] people = new int[numOfPeople];
            bool[] peopleFriends = new bool[numOfPeople];
            for (int i = 0; i < peopleFriends.Length; i++)
            {
                peopleFriends[i] = false;
            }

            Console.WriteLine("Enter friendships between people in format \"{person 1 number} {person 2 number}\"");
            for (int i = 0; i < numOfFriendships; i++)
            {
                int[] peopleRelation = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int person1 = peopleRelation[0] - 1;
                int person2 = peopleRelation[1] - 1;

                peopleFriends[person1] = true;
                peopleFriends[person2] = true;
            }

            Console.WriteLine("People with no friendships:");
            for (int person = 0; person < peopleFriends.Length; person++)
            {
                if (peopleFriends[person] == false)
                {
                    Console.Write($"{person + 1} ");
                }
            }

            Console.WriteLine();
        }
    }
}