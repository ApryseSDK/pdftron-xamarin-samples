using System;
using System.Collections.Generic;
using Android.Content;
using pdftron.Collab.DB;
using pdftron.Collab.DB.Entity;
using pdftron.Collab.Service;
using pdftron.Collab.Utils;

namespace CollaborationSample
{
    public class AnnotationService : Java.Lang.Object, ICustomService
    {
        CollabDatabase mDatabase;

        public AnnotationService(Context applicationContext)
        {
            mDatabase = CollabDatabase.GetInstance(applicationContext);
        }

        /// <summary>
        /// Must run on background thread
        /// </summary>
        public void SendAnnotation(string action, IList<AnnotationEntity> annotations, string documentId, string userName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Must run on background thread
        /// </summary>
        public void AddUser(CollabDatabase db, string userId, String userName)
        {
            CustomServiceUtils.AddUser(db, userId, userName);
        }

        /// <summary>
        /// Must run on background thread
        /// </summary>
        public void AddDocument(CollabDatabase db, string documentId)
        {
            CustomServiceUtils.AddDocument(db, documentId);
        }

        /// <summary>
        /// Must run on background thread
        /// </summary>
        public void AddAnnotations(CollabDatabase db, IDictionary<string, AnnotationEntity> annotations)
        {
            CustomServiceUtils.AddAnnotations(db, annotations);
        }

        /// <summary>
        /// Must run on background thread
        /// </summary>
        public void AddAnnotation(CollabDatabase db, AnnotationEntity annotation)
        {
            CustomServiceUtils.AddAnnotation(db, annotation);
        }

        /// <summary>
        /// Must run on background thread
        /// </summary>
        public void ModifyAnnotation(CollabDatabase db, AnnotationEntity annotation)
        {
            CustomServiceUtils.ModifyAnnotation(db, annotation);
        }

        /// <summary>
        /// Must run on background thread
        /// </summary>
        public void DeleteAnnotation(CollabDatabase db, string annotId)
        {
            CustomServiceUtils.DeleteAnnotation(db, annotId);
        }

        /// <summary>
        /// Must run on background thread
        /// </summary>
        public void Cleanup(CollabDatabase db)
        {
            CustomServiceUtils.Cleanup(db);
        }

        private AnnotationEntity CreateAnnotationEntity(string annotId, string documentId, string authorId, string userName, string xfdf)
        {
            var annotationEntity = new AnnotationEntity();
            annotationEntity.Id = annotId;
            annotationEntity.DocumentId = documentId;
            annotationEntity.AuthorId = authorId;
            annotationEntity.AuthorName = userName;
            annotationEntity.Xfdf = xfdf;
            XfdfUtils.FillAnnotationEntity(annotationEntity);
            return annotationEntity;
        }
    }
}