# Generated by Django 5.0.3 on 2024-04-01 15:03

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('backend', '0004_alter_client_country'),
    ]

    operations = [
        migrations.AlterField(
            model_name='client',
            name='country',
            field=models.CharField(max_length=100, null=True),
        ),
    ]