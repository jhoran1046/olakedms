using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Patterns
{
    public class CParentClass<T> : CNamedClass where T : class
    {
        private List<T> children_ = new List<T>();
    
        public List<T> Children
        {
            get
            {
                return children_;
            }
            set
            {
            }
        }

        /// <summary>
        /// Adds the child.
        /// </summary>
        /// <param name="aChild">A child.</param>
        public void AddChild(T aChild)
        {
            children_.Add(aChild);
        }
    }
}
