﻿using Manonero.MessageBus.Kafka.Settings;
using Microsoft.VisualBasic;
using System.Net.Http.Headers;

namespace TestKafka.Settings
{
    public class AppSetting
    {
        public string BootstrapServers { get; init; }
        public ConsumerSetting[] ConsumerSettings { get; init; }
        public ProducerSetting[] ProducerSettings { get; init; }

        public static AppSetting MapValue(IConfiguration configuration)
        {
           
            var bootstrapServers = configuration[nameof(BootstrapServers)];
            var consumerConfigurations = configuration.GetSection(nameof(ConsumerSettings)).GetChildren();
            var consumerSettings = new List<ConsumerSetting>();
            foreach (var consumerConfiguration in consumerConfigurations)
            {
                var consumerSetting = ConsumerSetting.MapValue(consumerConfiguration, bootstrapServers);
                if (!consumerSettings.Contains(consumerSetting))
                    consumerSettings.Add(consumerSetting);
            }

            var producerConfigurations = configuration.GetSection(nameof(ProducerSettings)).GetChildren();
            var producerSettings = new List<ProducerSetting>();
            foreach (var producerConfiguration in producerConfigurations)
            {
                var producerSetting = ProducerSetting.MapValue(producerConfiguration, bootstrapServers);
                if (!producerSettings.Contains(producerSetting))
                    producerSettings.Add(producerSetting);
            }
            var setting = new AppSetting
            {
                BootstrapServers = bootstrapServers,
                ConsumerSettings = consumerSettings.ToArray(),
                ProducerSettings = producerSettings.ToArray()
            };
            
            return setting;
        }
        public ConsumerSetting GetConsumerSetting(string id)
        => ConsumerSettings.FirstOrDefault(consumerSetting => consumerSetting.Id.Equals(id));
        public ProducerSetting GetProducerSetting(string id)
        => ProducerSettings.FirstOrDefault(producerSetting => producerSetting.Id.Equals(id));
    }
}
