import express from 'express';
import bodyParser from 'body-parser';
import { createConnection, getConnection } from 'typeorm';
import { Save } from './Entities/Save';

const app = express();
app.use(bodyParser.json());

const main = async () => {
  const conn = await createConnection({
    type: 'postgres',
    url: process.env.DATABASE_URL,
    logging: true,
    synchronize: true,
    entities: [Save],
  });

  await conn.runMigrations();

  app.get('/', (_, res) => {
    res.send('ok');
  });

  app.get('/load/:id', async (req, res) => {
    const data = await Save.findOne({ where: { uniqueId: req.params.id } });

    if (data) {
      res.send({
        level: data.level,
      });
    }
  });

  app.post('/save', async (req, res) => {
    const saveData = await Save.findOne({
      where: { uniqueId: req.body.uniqueId },
    });

    if (!saveData) {
      await getConnection()
        .createQueryBuilder()
        .insert()
        .into(Save)
        .values({
          level: req.body.level,
          uniqueId: req.body.uniqueId,
        })
        .returning('*')
        .execute();
    } else {
      const newSave = await getConnection()
        .createQueryBuilder()
        .update(Save)
        .set({ level: req.body.level })
        .where('uniqueId = :id', { id: req.body.uniqueId })
        .returning('*')
        .execute();
      res.send({
        level: newSave.raw[0].level,
      });
    }
  });

  app.listen(process.env.PORT, () => {
    console.log('running on port : ', process.env.PORT);
  });
};

main().catch((err) => {
  console.log(err);
});
