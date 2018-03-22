//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.7.99
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>[uBlogsy] [Base]</summary>
	[PublishedContentModel("uBlogsyBaseDocType")]
	public partial class UBlogsyBaseDocType : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "uBlogsyBaseDocType";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public UBlogsyBaseDocType(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<UBlogsyBaseDocType, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Invisible Redirect
		///</summary>
		[ImplementPropertyType("umbracoInternalRedirectId")]
		public string UmbracoInternalRedirectId
		{
			get { return this.GetPropertyValue<string>("umbracoInternalRedirectId"); }
		}

		///<summary>
		/// Hide from navigation
		///</summary>
		[ImplementPropertyType("umbracoNaviHide")]
		public bool UmbracoNaviHide
		{
			get { return this.GetPropertyValue<bool>("umbracoNaviHide"); }
		}

		///<summary>
		/// 302 Redirect
		///</summary>
		[ImplementPropertyType("umbracoRedirect")]
		public string UmbracoRedirect
		{
			get { return this.GetPropertyValue<string>("umbracoRedirect"); }
		}

		///<summary>
		/// Url Alias
		///</summary>
		[ImplementPropertyType("umbracoUrlAlias")]
		public string UmbracoUrlAlias
		{
			get { return this.GetPropertyValue<string>("umbracoUrlAlias"); }
		}

		///<summary>
		/// Url Name Change
		///</summary>
		[ImplementPropertyType("umbracoUrlName")]
		public string UmbracoUrlName
		{
			get { return this.GetPropertyValue<string>("umbracoUrlName"); }
		}
	}
}