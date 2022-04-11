using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElastiSearchIntegration
{

    public class Elasticsearch
    {
        ElasticClient client = null;
        public Elasticsearch()
        {
            var uri = new Uri("https://elastic:m5VyGNWW*q9KBrvWfsYH@localhost:9200");
            var settings = new ConnectionSettings(uri).DefaultIndex("city").ServerCertificateValidationCallback(CertificateValidations.AllowAll);

            client = new ElasticClient(settings);
        }
        public List<City> GetResult()
        {
            if (client.Indices.Exists(Indices.Parse("city")).Exists)
            {
                var response = client.Search<City>();
                return response.Documents.ToList();
            }
            return null;
        }

        public List<City> GetResult(string condition)
        {
            if (client.Indices.Exists(Indices.Parse("city")).Exists)
            {
                var query = condition;

                var searchResponse = client.Search<City>(s => s
                    .Query(q => q
                        .Match(m => m
                            .Field(f => f.Name)
                            .Query(condition)
                        )
                    )
                ).Documents.ToList();
                return searchResponse;

                //return client.SearchAsync<City>(s => s
                //.From(0)
                //.Take(10)
                //.Query(qry => qry
                //    .Bool(b => b
                //        .Must(m => m
                //            .QueryString(qs => qs
                //                .DefaultField("_all")
                //                .Query(query)))))).Result.Documents.ToList();
            }
            return null;
        }

        public void AddNewIndex(City model)
        {
            try
            {
                client.IndexAsync<City>(model, null).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}

