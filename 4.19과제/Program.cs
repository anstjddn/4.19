using System.Collections.Generic;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace _4._19과제
{

    public class LinkedListNode<T>
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> next;
        internal LinkedListNode<T> prev;
        private T item;

        public LinkedListNode(T value)                                          //생성자 설정
        {
            this.list = null;
            this.next = null;
            this.prev = null;
            this.item = value;
        }
        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.next = null;
            this.prev = null;
            this.item = value;
        }
        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> next, LinkedListNode<T> prev, T value)
        {
            this.list = list;
            this.next = next;
            this.prev = prev;
            this.item = value;
        }
        public LinkedListNode<T> Next { get { return next; } }              // .Next같은거 사용할떄 불러오는값 설정
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Value { get { return Value; } set { Value = value; } }               // 값불러내기??
    }
    public class LinkedList<T>              // 초기 생성자설정
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;
        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            count = 0;
        }


        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddFirst(T Value)                          // 맨앞에 추가
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, Value);
            LinkedListNode<T> prveNode = head;
            if (head != null)
            {
                newNode = head;                             // 앞에 붙힌 새로운 노드가 head가 되고 
                newNode.next = prveNode;                    // 기존 head 였던 prveNode는 새로운 head Node의 다음이 되게 설정 

            }
            else
            {
                newNode = head;
                newNode = tail;
            }
            count++;
            return newNode;

        }
        public LinkedListNode<T> AddLast(T Value)              // 맨뒤에 추가
        {
            LinkedListNode<T> newnode = new LinkedListNode<T>(this, Value);
            LinkedListNode<T> prveNode = tail;                  // 기존 맨뒤node를 tail로 설정
            if (tail != null)
            {
                newnode = tail;                 // 앞에 붙힌 새로운 노드가 head가 되고 
                prveNode.next = newnode;         // 기존 head 였던 prveNode는 새로운 head Node의 다음이 되게 설정 
            }
            else
            {
                newnode = head;                 // 뒤에가 null이면 newnode가 머리이자 꼬리가 되게끔
                newnode = tail;
            }
            count++;
            return newnode;

        }
        public LinkedListNode<T> AddBefore(LinkedListNode<T> Node, T Value)            //내가 중간에 삽입하고자 하는 위치랑 값을 넣고
        {
            LinkedListNode<T> newnode = new LinkedListNode<T>(this, Value);


            if (Node.prev != null)                                                  // 넣고자하는 노드 앞에 다른 노드가 있다면
            {
                Node.prev.next = newnode.prev;                                          // 이전의 노드의 다음을 새로운 노드의 이전을 나타내고
                Node.prev = newnode.next;                                              // 삽입하고자하는 이전을 앞에넣은 노드의 다음값으로 받음

            }
            else
            {
                newnode = head;                                         // 넣는 노드 가 head라면  새로운 노드를 head 로 두고 
                Node.prev = newnode.next;                               // 삽입하고자하는 노드 이전값을 새로운 노드값으로 받는다
            }

            count++;
            return newnode;

        }
        public LinkedListNode<T> AddAffer(LinkedListNode<T> Node, T Value)            //내가 중간에 삽입하고자 하는 위치랑 값을 넣고
        {
            LinkedListNode<T> newnode = new LinkedListNode<T>(this, Value);


            if (Node.next != null)                                                  // 넣고자하는 노드 뒤에 다른 노드가 있다면
            {
                Node.next.prev = newnode.next;                                          // 뒤에 노드의 이전값을 중간에 끼는 노드의 다음값으로 설정하고
                Node.next = newnode.prev;                                              // 기존 노드의 다음값을 중간에 끼는 노드의 이전값으로 설정한다.

            }
            else
            {
                newnode = tail;                                         // 끼워넣고자하는 노드가 마지막부분이면 끼워넣는노드를 tail로 받고 
                Node.next = newnode.prev;                               // 기존노드의 다음값을 마지막 노드의 이전값으로 설정한다.
            }

            count++;
            return newnode;

        }

        public LinkedListNode<T> Remove(T Value)
        {
            LinkedListNode<T> newnode = new LinkedListNode<T>(this, Value);


            count--;
            return newnode;
        }
       
       /* public LinkedListNode<T> Find(T Value)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;                     // 비교하는클래스로 사용
            if (Value != null)
            {
                
            }


        }*/

    }

}
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


// Remove(T Value) 는 bool
// Remove(node)는 void
// Find 는 그냥 public

