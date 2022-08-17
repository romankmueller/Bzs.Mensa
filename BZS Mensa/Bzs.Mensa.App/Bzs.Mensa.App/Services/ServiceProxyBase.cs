using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Bzs.Mensa.Shared.DataTransferObjects;
using RestSharp;

namespace Bzs.Mensa.App.Services
{
    /// <summary>
    /// Represents a service proxy base.
    /// </summary>
    public abstract class ServiceProxyBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProxyBase" /> class.
        /// </summary>
        protected ServiceProxyBase()
        {
            this.BaseUri = new Uri(@"https://bzsmensa.azurewebsites.net/api/");
        }

        /// <summary>
        /// Gets the base URI.
        /// </summary>
        protected Uri BaseUri { get; }

        /// <summary>
        /// Executes a GET request.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="resource">The resource.</param>
        /// <returns>The task.</returns>
        protected async Task<TResult> GetAsync<TResult>(string resource)
            where TResult : DtoBase
        {
            RestClient client = new RestClient(this.BaseUri);
            RestRequest request = new RestRequest(resource, Method.Get);
            RestResponse response = null;
            try
            {
                response = await client.GetAsync(request).ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            if (response != null)
            {
                return DtoBase.Create<TResult>(response.Content);
            }

            return null;
        }

        /// <summary>
        /// Executes a GET request for a list.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="resource">The resource.</param>
        /// <returns>The task.</returns>
        protected async Task<List<TResult>> GetListAsync<TResult>(string resource)
            where TResult : DtoBase
        {
            RestClient client = new RestClient(this.BaseUri);
            RestRequest request = new RestRequest(resource, Method.Get);
            RestResponse response = null;
            try
            {
                response = await client.ExecuteGetAsync(request).ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            if (response != null)
            {
                return DtoBase.CreateList<TResult>(response.Content);
            }

            return null;
        }

        /// <summary>
        /// Executes a GET request.
        /// </summary>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <param name="resource">The resource.</param>
        /// <returns>The task.</returns>
        protected async Task<TResult> PostAsync<TRequest, TResult>(string resource, TRequest data)
            where TRequest : DtoBase
            where TResult : DtoBase
        {
            RestClient client = new RestClient(this.BaseUri);
            RestRequest request = new RestRequest(resource, Method.Post);
            request.AddBody(data.ToJson());
            RestResponse response = null;
            try
            {
                response = await client.ExecutePostAsync(request).ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            if (response != null)
            {
                return DtoBase.Create<TResult>(response.Content);
            }

            return null;
        }

        protected async Task<TResult> DeleteAsync<TResult>(string resource)
            where TResult : DtoBase
        {
            RestClient client = new RestClient(this.BaseUri);
            RestRequest request = new RestRequest(resource, Method.Delete);
            RestResponse response = null;
            try
            {
                response = await client.DeleteAsync(request).ConfigureAwait(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            if (response != null)
            {
                return DtoBase.Create<TResult>(response.Content);
            }

            return null;
        }
    }
}
