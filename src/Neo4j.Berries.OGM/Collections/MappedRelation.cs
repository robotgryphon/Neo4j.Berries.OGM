using Neo4j.Driver;
using Neo4j.Driver.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Neo4j.Berries.OGM.Collections
{
    public record struct MappedRelation<S, R, T>(S SourceNode, R Relationship, T TargetNode)
    {

        public static MappedRelation<S, R, T> FromQuery<S, R, T>(IRecord record, string sSource, string sRelationship, string sTarget)
        {
            
        }
    }
}
