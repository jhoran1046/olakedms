using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Framework.Patterns
{
    /// <summary>
    /// 
    /// </summary>
    public class CNamedClass
    {
        private string name_;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Browsable(false)]
        [ReadOnly(true)]
        public virtual string Name
        {
            get
            {
                return name_;
            }
            set
            {
                name_ = value;
            }
        }
    }
}
