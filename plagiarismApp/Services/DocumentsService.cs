using AutoMapper;
using plagiarismApp.Database;
using plagiarismModel.TableRequests.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace plagiarismApp.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly plagiarismContext _context;
        private readonly IMapper _mapper;
        public DocumentsService(plagiarismContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<plagiarismModel.Documents> Get(DocumentsSearchRequest request)
        {
            var query = _context.Set<Documents>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Text))
            {
                query = query.Where(x => x.Text.StartsWith(request.Text));
            }
            if (!string.IsNullOrWhiteSpace(request?.Title))
            {
                query = query.Where(x => x.Title.StartsWith(request.Title));
            }
            if (!string.IsNullOrWhiteSpace(request?.Author))
            {
                query = query.Where(x => x.Author.StartsWith(request.Author));
            }
            if (!string.IsNullOrWhiteSpace(request?.Publisher))
            {
                query = query.Where(x => x.Publisher.StartsWith(request.Publisher));
            }
            if (!string.IsNullOrWhiteSpace(request?.Type))
            {
                query = query.Where(x => x.Type.StartsWith(request.Type));
            }
            if (!string.IsNullOrWhiteSpace(request?.Extension))
            {
                query = query.Where(x => x.Extension.StartsWith(request.Extension));
            }

            //  EXPRESSION TRY
            // this represents the argument to your lambda expression
            //var parameter = Expression.Parameter(typeof(plagiarismModel.Documents), "qo");

            //// this is the "qo.QueriedField" part of the resulting expression - we'll use it several times later
            //var memberAccess = Expression.Field(parameter, "Text");

            //// start with a 1 == 1 comparison for easier building - 
            //// you can just add further &&s to it without checking if it's the first in the chain
            //var expr = Expression.Equal(Expression.Constant(1), Expression.Constant(1));

            //// doesn't trigger, so you still have 1 == 1
            //if (request.matches != null || request.matches.Count != 0)
            //{
            //    foreach (var item in request.matches)
            //    {
            //        expr = Expression.OrElse(expr, Expression.Equal(memberAccess, Expression.Constant(item)));
            //    }
            //}
            //// now, we combine the lambda body with the parameter to create a lambda expression, which can be cast to Expression<Func<X, bool>>
            //var lambda = (Expression<Func<Documents, bool>>)Expression.Lambda(expr, parameter);

            //// you can now do this, and the Where will be translated to an SQL query just as if you've written the expression manually
            //query = query.Where(lambda);


            // ints
            if (request?.Id.HasValue == true)
            {
                query = query.Where(x => x.Id == request.Id);
            }
            if (request?.PackageTypeId.HasValue == true)
            {
                query = query.Where(x => x.PackageTypeId == request.PackageTypeId);
            }
            if (request?.TimeUsed.HasValue == true)
            {
                query = query.Where(x => x.TimeUsed == request.TimeUsed);
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.Documents>>(list);
        }

        public plagiarismModel.Documents GetById(int id)
        {
            var entity = _context.Documents.Find(id);

            return _mapper.Map<plagiarismModel.Documents>(entity);
        }

        public plagiarismModel.Documents Insert(DocumentsUpsertRequest request)
        {
            var entity = _mapper.Map<Documents>(request);

            _context.Documents.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<plagiarismModel.Documents>(entity);
        }

        public plagiarismModel.Documents Update(int id, DocumentsUpsertRequest request)
        {
            var entity = _context.Documents.Find(id);
            _context.Documents.Attach(entity);
            _context.Documents.Update(entity);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<plagiarismModel.Documents>(entity);
        }

        public List<plagiarismModel.Documents> Plagiarism(DocumentsSearchRequest request)
        {
            var query = _context.Set<Documents>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Text))
            {
                query = query.Where(x => x.Text.ToLower().Contains(request.Text.ToLower()));
            }
            var list = query.ToList();

            return _mapper.Map<List<plagiarismModel.Documents>>(list);
        }
    }
}
