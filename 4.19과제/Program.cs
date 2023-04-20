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

        public bool  Remove(T Value)                                        // Remove값을 지우는건 bool이라 bool사용
        {
            LinkedListNode<T> Findnode = Find(Value);                               // Find로 찾아서 Findnode로 설정

            if (Findnode != null)                                   // Findnode 가 null이 아니면 Remove(node)를 사용 
            {
                Remove(Findnode);
                return true;
            }
            else false;
            count--;
        }
       
        public LinkedListNode<T> Find(T Value)
        {
            LinkedListNode<T> Findnode = head;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;                     // 비교하는클래스로 사용
            
            while(Findnode != null)                                         
            {
                if (comparer.Equals(Value, Findnode.Value))                                 //Findnode의 Value 와 내가 찾을려고하는 값을 비교하여 같으면 Findnode를 리턴하고
                {
                    return Findnode;
                }
                else Findnode.next;                                                     // 아니면 다음 노드랑 비교
            }

            return null;                                                            // 없으면 null을 리턴
        }

    }
    public void Remove(LinkedListNode<T> node)
    {

        // 지울려고하는 노드가 head나 tail의 경우
        if (node == head) { node.next == head; }                    // 삭제하는거 이전이나 이후를 head또는 tail로 설정
        if( node == tail) { node.prev == tail; }
        

        // 지울려고하는 노드가 중간에 껴있는경우
        if(node.prev != null)                   //중간에 노드를 지울떄 지울려고하는 노드의 전의 next를 지울려고하는 노드의 next로 지정해서 지울려고 하는 node의 next랑 연결
        {
            node.prev.next = node.next;                     
        }
        if(node.next!= null)                //중간에 노드를 지울떄 지울려고하는 노드의 앞의 prev를 지울려고하는 노드의 prev로 지정해서 지울려고 하는 node의 prev랑 연결
        {
            node.next.prev = node.prev;
        }

        count--;

    }

}
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


