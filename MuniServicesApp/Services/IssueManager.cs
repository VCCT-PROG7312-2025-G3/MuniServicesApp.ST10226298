using System;
using System.Collections.Generic;
using System.Linq;
using MuniServicesApp.Models;

namespace MuniServicesApp.Services
{
    public class IssueManager
    {
        private static IssueManager _instance;
        private static readonly object _lock = new object();
        private List<Issue> _issues;
        private int _nextId;

        private IssueManager()
        {
            _issues = new List<Issue>();
            _nextId = 1;
        }

        public static IssueManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new IssueManager();
                    }
                }
                return _instance;
            }
        }

        public void AddIssue(Issue issue)
        {
            issue.Id = _nextId++;
            _issues.Add(issue);
        }

        public List<Issue> GetAllIssues()
        {
            return _issues.ToList();
        }

        public Issue GetIssueById(int id)
        {
            return _issues.FirstOrDefault(i => i.Id == id);
        }

        public int GetIssueCount()
        {
            return _issues.Count;
        }
    }
}
