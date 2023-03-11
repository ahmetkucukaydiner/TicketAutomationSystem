using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class LineManager : ILineService
    {
        private ILineDal _lineDal;

        public LineManager(ILineDal lineDal)
        {
            _lineDal = lineDal;
        }

        public IResult Add(Line line)
        {
            _lineDal.Add(line);
            return new SuccessResult(Messages.LineAdded);
        }

        public IResult Delete(Line line)
        {
            _lineDal.Delete(line);
            return new SuccessResult(Messages.LineDeleted);
        }

        public IResult Update(Line line)
        {
            _lineDal.Update(line);
            return new SuccessResult(Messages.LineUpdated);
        }

        public IDataResult<List<Line>> GetAll()
        {
            return new SuccessDataResult<List<Line>>(_lineDal.GetAll());
        }

        public IDataResult<Line> GetById(int id)
        {
            return new SuccessDataResult<Line>(_lineDal.Get(l => l.Id == id));
        }
    }
}
