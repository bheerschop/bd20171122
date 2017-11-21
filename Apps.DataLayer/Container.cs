//Container.cs
using System.Collections.Generic;

namespace Apps.DataLayer
{
    public delegate bool CheckerInvoker<TypeOfItem>(TypeOfItem contactToCkeck);

    public class Container<TypeOfItem>
    {
        /// <summary>
        /// Initializes a Container with room for 100 Items
        /// </summary>
        public Container()
        {
           items = new TypeOfItem[100];
        }
        private TypeOfItem[] items;

        /// <summary>
        /// The number of items currently in the Container
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Gets an Item from the Container
        /// </summary>
        /// <param name="index">The position of the item to retrieve</param>
        /// <returns></returns>
        public TypeOfItem this[int index]
        {
            get
            {
                return items[index];
            }
        }

        /// <summary>
        /// Adds an item in the correct position. 
        /// Eventually increases the size of the container of another 100 places if necessary.
        /// </summary>
        /// <param name="toAdd">The item to insert in the container</param>
        public void Add(TypeOfItem toAdd)
        {
            //if we have no more room in the list
            if (Count >= items.Length)
            {
                //we create a temporary list bigger than the previous 
                TypeOfItem[] temp = new TypeOfItem[items.Length + 100];
                for (int i = 0; i < items.Length; i++)
                {
                    //we reference all the old items from the new list
                    temp[i] = items[i];
                }
                //our list is now the new list
                items = temp;
            }
            //we add the item and increment the count
            items[Count++] = toAdd;
        }

        /// <summary>
        /// Used by the foreach loop
        /// </summary>
        /// <returns>The enumerator of the items in the container</returns>
        public IEnumerator<TypeOfItem> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        /// <summary>
        /// Copies the elements of the Container to a new Array
        /// </summary>
        /// <returns>An Array full of the elements of the Container</returns>
        public TypeOfItem[] ToArray() {
            TypeOfItem[] result = new TypeOfItem[Count];
            for (int i = 0; i < Count; i++) {
                result[i] = items[i];
            }
            return result;
        }
        
        public Container<TypeOfItem> Filter(CheckerInvoker<TypeOfItem> checkContact)
        {
            Container<TypeOfItem> temp = new Container<TypeOfItem>();
            foreach (TypeOfItem item in items)
            {
                if (item!=null && checkContact(item))
                    temp.Add(item);
            }
            return temp;
        }
    }
}
