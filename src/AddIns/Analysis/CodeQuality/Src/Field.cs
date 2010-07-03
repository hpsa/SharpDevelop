﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickGraph;

namespace ICSharpCode.CodeQualityAnalysis
{
    public class Field : IDependency
    {
        /// <summary>
        /// Name of field
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of field
        /// </summary>
        public Type FieldType { get; set; }

        /// <summary>
        /// Type which owns this field
        /// </summary>
        public Type Owner { get; set; }

        /// <summary>
        /// Whether this field is event
        /// </summary>
        public bool IsEvent { get; set; }
        
        public BidirectionalGraph<object, IEdge<object>> BuildDependencyGraph()
        {
            return null;
        }

        public override string ToString()
        {
            return Name;
        }
        
    }
}
