﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<PersonAggregate.Person> FindAllAsync();

        Task UpdateAsync(Person person);
    }
}
