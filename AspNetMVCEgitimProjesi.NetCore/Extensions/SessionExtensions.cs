﻿using System.Text.Json;

namespace AspNetMVCEgitimProjesi.NetCore.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session, string key) where T : class
        {
            var data = session.GetString(key);
            return data == null ?
                default : JsonSerializer.Deserialize<T>(data);
        }
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
        public static void Remove(this ISession session, string key)
        {
            session.Remove(key);
        }
        //public static void SetObject<T>(this ISession session, string key, T value)
        //{
        //    session.SetString(key, JsonSerializer.Serialize(value));
        //}
    }
}
