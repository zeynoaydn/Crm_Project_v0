using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class CountriesManager : ICountriesService
    {
        private ICountriesDal _countriesDal;
        public CountriesManager(ICountriesDal countriesDal)
        {
            _countriesDal = countriesDal;
        }
        public IDataResult<List<Countries>> GetAll()
        {
            return new SuccessDataResult<List<Countries>>(_countriesDal.GetAll(), Messages.CountriesListed);
        }
    }
}
