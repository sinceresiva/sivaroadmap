using System.Collections.Generic;

    namespace CQAssured_Review.Models{
    public class Review{
        public int Id{get;set;}
        public List<string> CodeSets{get;set;}
        public string RaisedBy{get;set;}
        public string AssignedTo{get;set;}
        public ReviewStatus Status{get;set;}
    }
}