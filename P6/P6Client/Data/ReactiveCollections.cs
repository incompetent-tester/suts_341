using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Subjects;

namespace P6Client.Data
{
    public class ReactiveCollections
    {
        public ReplaySubject<String> subjects = new ReplaySubject<String>();
    }
}
