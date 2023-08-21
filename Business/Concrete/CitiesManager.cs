using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CitiesManager : ICitiesService
    {
        //private ICitiesDal _citiesDal;
        //public CitiesManager(ICitiesDal citiesDal)
        //{
        //    _citiesDal = citiesDal;
        //}
        //public IDataResult<List<Cities>> GetAll()
        //{
        //    return new SuccessDataResult<List<Cities>>(_citiesDal.GetAll(),Messages.CitiesListed);
        //}
        private ICitiesDal _citiesDal;
        public CitiesManager(ICitiesDal citiesDal)
        {
            _citiesDal = citiesDal;
        }
        public IDataResult<List<Cities>> GetAll()
        {
            return new SuccessDataResult<List<Cities>>(_citiesDal.GetAll());
        }
    }
}
