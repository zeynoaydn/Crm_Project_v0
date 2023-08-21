using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface ICountriesService
    {
        IDataResult<List<Countries>> GetAll();
    }
}
