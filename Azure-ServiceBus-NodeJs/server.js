const express = require('express');
const { ServiceBusClient, delay } = require('@azure/service-bus');

const app = express();
// Aktivera deserialisering av request body...
// Få ut json data som skickas i body delen i requestet...
app.use(express.json());

const connectionString =
  'Endpoint=sb://westcoastcars-bus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=TfVJUa7vFDDV5MAWfynhfmxZShn8YDk8v+ASbG5YU6o=';

// Skapa en POST endpoint för att skicka in bilar...
app.post('/api/vehicles', async (req, res) => {
  console.log(req.body);

  const client = new ServiceBusClient(connectionString);
  const sender = client.createSender('vehiclesqueue');

  try {
    let batch = await sender.createMessageBatch();
    const message = { body: req.body };

    console.log(message);

    if (!batch.tryAddMessage(message)) {
      res.status(400).json({
        success: false,
        message: 'Meddelandet är för stort!',
        data: [],
      });
    }

    await sender.sendMessages(batch);

    res
      .status(201)
      .json({ success: true, message: 'Bilarna mottagna', data: req.body });
  } catch (error) {
    res.status(500).json({ success: false, message: error.message, data: [] });
  } finally {
    await sender.close();
    await client.close();
  }
});

// Skapa en endpoint för att fejka valuation tjänsten
app.get('/api/valuations/messages', async (req, res) => {
  const client = new ServiceBusClient(connectionString);
  const receiver = client.createReceiver('vehiclesqueue');

  let receivedMessages;
  receiver.subscribe({
    processMessage: (messages) => {
      receivedMessages = messages.body;
      console.log(
        'Received messages ',
        receivedMessages,
        messages.body,
        messages
      );
    },
    processError: (error) => {
      console.log('Error: ', error);
    },
  });

  await delay(2000);

  await receiver.close();
  await client.close();

  res
    .status(200)
    .json({ success: true, message: 'Det fungerar', data: receivedMessages });
});

// const errorHandler = async (error)=>{
//   console.log("Error: ", error);
// }

app.listen(3000, () => console.log('Server is up and running'));
