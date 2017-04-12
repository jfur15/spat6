﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3
{
    class ComparisonPool
    {
        string classifier;
        List<Paragraph> pool;

        public string Classifier { get { return classifier; } }
        public List<Paragraph> Pool { get { return pool; } set { pool = value; } }

        public ComparisonPool(string subject)
        {
            classifier = subject;
            pool = new List<Paragraph>();
        }

        public void addParagraph(Paragraph temp)
        {
            pool.Add(temp);
        }

    }
}
