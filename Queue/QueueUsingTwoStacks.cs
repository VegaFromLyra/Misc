    class QueueUsingTwoStacks
    {
        private Stack<int> stack1;
        private Stack<int> stack2;

        public QueueUsingTwoStacks()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        public void Enqueue(int data)
        {
            if (stack1.Count == 0)
            {
               stack1.Push(data);
            }  
            else
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }

                stack1.Push(data);

                while (stack2.Count > 0)
                {
                    stack1.Push(stack2.Pop());
                }  
            }
        }

        public int Dequeue()
        {
            if (stack1.Count == 0)
            {
                throw new Exception("Empty queue");
            }    

            return stack1.Pop();
        }

        public int Peek()
        {
            if (stack1.Count == 0)
            {
                throw new Exception("Empty queue");
            }    

            return stack1.Peek();
        }
    }