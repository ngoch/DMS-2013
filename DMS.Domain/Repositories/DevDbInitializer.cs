using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Domain.Repositories
{
    public class DevDbInitializer : DropCreateDatabaseIfModelChanges<DMSDbContext>
    {
        protected override void Seed(DMSDbContext context)
        {
            var userSet = context.Set<User>();
            for (int i = 0; i < 10; i++)
            {
                User user = new User();
                user.Name = "Expert " + i;
                user.PasswordHash = "202CB962AC59075B964B07152D234B70";
                userSet.Add(user);
            }

            User administrator = new User()
            {
                Name = "Admin",
                PasswordHash = "202CB962AC59075B964B07152D234B70",
            };

            userSet.Add(administrator);

            var questions = new PsychometricQuestion[]{ new PsychometricQuestion
              {
                  Body = "საკუთარ ბიზნეს/პროფესიულ საქმიანობაში თქვენs",
                  Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ჩვეულებრივ არ გიწევთ კონკურსში მონაწილეობის მიღება", Index = 0, Points =0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "იღებთ მონაწილებას კონკურსში წინასწარი გათვალისწინებით და ეძებთ გზებს მისი თავიდან მოცილებისა და შემცირების", Index = 1, Points = 1 },
                       new PsychometricQuestionPossibleAnswer(){ AnswerText = "ებრძვით მოწინააღმდეგეებს", Index = 2, Points = 2 },
                        new PsychometricQuestionPossibleAnswer(){ AnswerText = "მზად ხართ იბრძოლოთ კონკურენტების წინააღმდეგ ნებისმიერი საშუალებით და დარწმუნებული ხართ გამარჯვებაში", Index = 3, Points = 3 },
                         new PsychometricQuestionPossibleAnswer(){ AnswerText = "ჩართული ხართ იმ მიზნით, რომ თავიდან აიცილოთ კონკურსი", Index = 4, Points = 1 },
                         new PsychometricQuestionPossibleAnswer(){ AnswerText = "მოგწონთ ბრძოლა კონკურსში", Index = 5, Points = 2 },
                          new PsychometricQuestionPossibleAnswer(){ AnswerText = "გრძნობთ, რომ მზად ხართ აღმოფხვრათ კონკურსი საერთო კეთილდღეობისთვის", Index = 6, Points = 1 }

                  }
              },
              new PsychometricQuestion
              {
                  Body = "მანქანის მართვის დროს თქვენ",
                  Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ყოველთვის ემორჩილებით საგზაო წესებს და თავიდან იცილებთ სახიფათო სიტუაციებს", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "პრაქტიკულად ყოველთვის ემორჩილებით მოძრაობის წესებს, მაგრამ თუ დაარღვევთ ამაზე არასდროს ეკამათებით პოლიციას", Index = 1, Points =1  },
                           new PsychometricQuestionPossibleAnswer(){ AnswerText = "მშვიდად რეაგირებთ, როცა გაჯარიმებენ", Index = 2, Points = 2 },
                                new PsychometricQuestionPossibleAnswer(){ AnswerText = "სავარაუდოდ არღვევთ წესებს, თუ იცით რომ არ დაგაჯარიმებენ", Index =3 , Points = 3 },
                                     new PsychometricQuestionPossibleAnswer(){ AnswerText = "პრაქტიკულად ყოველთვის ემორჩილებით საგზაო წესებს და მართავთ ფრთხილად", Index = 4, Points = 1 },
                                          new PsychometricQuestionPossibleAnswer(){ AnswerText = "ხშირად არღვევთ წესებს: სიჩქარის ლიმიტის გადაჭარბებით  გასწრების შემთხვევაში", Index =5 , Points =  2},
                                               new PsychometricQuestionPossibleAnswer(){ AnswerText = "ცდილობთ დაემორჩილოთ წესებს, სანამ ისინი ხელს არ უშლიან თქვენ მიზნებს, წინააღმდეგ შემთხვევაში მათ დააიგნორებთ. ", Index = 6, Points = 2 }
                  }
              },

               new PsychometricQuestion
               {
                   Body = "უმრავლესობის აზრი",
                   Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ჩვეულებრივ ეთანხმებით მას  ", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თუ თქვენი აზრი განსხვავებულია, მაშინ იცავთ საკუთარს  ", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თუ თქვენი აზრი განსხვავებულია, მაშინ გამოხატავთ მას და უნარჩუნებთ საკუთარ შეხედულებებს  ", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "თუ თქვენი აზრი განსხვავებულია. თქვენ უსმენთ სხვებს გაღიზიანებულად, სანამ არ განიხილავთ საკუთარ აზრს, როგორც ერთადერთ სწორ ვარიანტს.", Index =3 , Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თუ თქვენი აზრი განსხვავებულია საზოგადო აზრისგან, თქვენ ვერ ბედავთ მიჰყვეთ საკუთარს", Index = 4, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "არ აქვს მნიშვნელობა თქვენთვის", Index =5 , Points =  0},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თქვენ ეკამათებით ყველანაირად, რათა თქვენი მხარე დაიჭიროს ყველამ და შეიცვალონ აზრი.", Index = 6, Points = 3 }
                  }
               },

               new PsychometricQuestion
               {
                   Body = "როცა ახორციელებთ თქვენ მიზანს, მაშინ",
                   Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "არასდროს არღვევთ კანონს", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "არ დაარღვევთ კანონს მკაფიოდ, მაგრამ გამოიყენებთ მის (loopholes-ამბრაზურები) საჭიროების შემთხვევაში", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ზოგჯერ არღვევთ კანონს უმნიშვნელო საკითხზე და ფიქრობთ, რომ ეს არაფერია ", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "ზოგჯერ არღვევთ კანონს, თუ მისი აღმოჩენის რისკი მცირეა", Index =3 , Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "შეიძლება დაარღვიოთ კანონი, თუ ხედავთ რომ ამას სხვები აკეთებენ", Index = 4, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "სავარაუდოდ არღვევთ კანონს, თუ არის შანსი, რომ მისი გამოვლინება დაიფაროს", Index =5 , Points =  2
                      },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "მზად ხართ ყველაფრისთვის, რადგან ფიქრობთ, რომ დიდი მიზანი ამართლებს ნებისმიერ საშუალებას", Index = 6, Points = 3 }
                  }
               },

                new PsychometricQuestion
                {
                    Body = "თუ დუელი ისევ იქნა დაშვებული, მაშინ  თქვენ",
                    Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "შეეცდებით თავი აარიდოთ მას, თუ არის საშუალება, მაგრამ თუ იქნა დანიშნული უკან არ დაიხევთ", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თავიდან აიცილებთ ნებისმიერ ფასად", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "გირჩევნიათ კონფლიქტის მოგვარება სასამართლოში", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "მიიღებთ გამოწვევას, მაგრამ შერიგებასაც ასევე", Index =3 , Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "შეიძლება დაარღვიოთ კანონი, თუ ხედავთ რომ ამას სხვები აკეთებენ", Index = 4, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "სავარაუდოდ არღვევთ კანონს, თუ არის შანსი, რომ მისი გამოვლინება დაიფაროს", Index =5 , Points =  2
                      },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "მზად ხართ ყველაფრისთვის, რადგან ფიქრობთ, რომ დიდი მიზანი ამართლებს ნებისმიერ საშუალებას", Index = 6, Points = 3 }
                  }
                },
                 new PsychometricQuestion
                 {
                     Body = "თამაშის(აზარტული თამაშები) შანსის შემთხვევაში  თქვენ",
                     Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "არ თამაშობთ", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თუ ითამაშებთ მხოლოდ დაბალი ფსონებით", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "შეიძლება ითამაშოთ, მაგრამ არასდროს გადააცილებთ არსებული თანხის ლიმიტს", Index = 2, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "ითამაშებთ მაღალი ფსონებით, ზოგჯერ გადაჭარბებით ლიმიტზე", Index =3 , Points =3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ზოგადად აღარ თამაშობთ, რაც გძულთ წაგება( წარუმატებელი შემთხვევის გამო)", Index = 4, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "როცა თამაშობთ, ზოგჯერ რისკავთ ყველაფრით", Index =5 , Points =  3
                      },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " პრინციპულად არ თამაშობთ", Index = 6, Points = 0 }
                  }
                 },
                 new PsychometricQuestion
                 {
                     Body = "თქვენ ანიჭებთ უპირატესობას იმ ადამიანებს, რომლებიც",
                     Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "არიან სანდო ", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "მუშაობენ თქვენთან ერთად", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "არიან კომპეტენტურები, მზრუნველები(გატაცებული საქმით)", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "არიან მოწადინებულები, სავსე ინიციატივით", Index =3 , Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "არიან ნდობით აღჭურვილნი თქვენ მიმართ და სავსებით მორჩილნი", Index = 4, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "არიან მამაცები, რისკების მოყვარული", Index =5 , Points =  3
                      },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "სჯერათ თქვენი იდეების", Index = 6, Points = 1 }
                  }
                 },
                 new PsychometricQuestion
                 {
                     Body = "სოციალურ გარემოცვაში  თქვენ",
                     Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "უერთდებით იმას, რაც იქ ხდება", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ელაპარაკებით იმ ადამიანებს, რომელნიც ჩანან საინტერესონი", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "არის სიცოცხლე და სულის ნაწილი თქვენთვის", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "გინდათ, რომ მოიპოვოთ პატივისცემა და აღიარება", Index =3 , Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "უსმენთ რასაც ლაპარაკობენ, მაგრამ არ გაქვთ გამბედაობა შეუერთდეთ საუბარს", Index = 4, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ხშირად ეძებთ თავგადასავლებს", Index =5 , Points =  3
                      },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ამბობთ(უზიარებთ) თქვენ იდეებს", Index = 6, Points = 2}
                  }
                 },
                 new PsychometricQuestion
                 {
                     Body = "როცა გადაწყვეტილებას იღებთ  თქვენ",
                     Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ჩვეულებრივ აყოვნებთ დიდი ხნით", Index = 0, Points = 1},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "გადაწყვეტთ მას შემდეგ, რაც შეაფასებთ წარმატების პერსპექტივას", Index = 1, Points =0  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თქვენი გადაწყვეტილება ეყრდნობა უფრო წარმატებას, ვიდრე საფუძვლიან ანგარიშს", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "გაითვალისწინებთ, რომ არ არსებობს ეჭვი თქვენი სიმართლის შესახებ", Index =3 , Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "გაქვთ ტენდენცია მისი გადადების", Index = 4, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "იმპულსურად გადაწყვეტთ, ეყრდნობით მხოლოდ ბედს და იღბალს", Index =5 , Points =  3
                      },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "მტკიცედ გჯერათ თქვენი სიმართლის", Index = 6, Points = 3 }
                  }
                 },
                  new PsychometricQuestion
                  {
                      Body = "თქვენ ხართ მოლოდინში დაგეგმილი ღონისძიების, იქნება თუ არა  ხელსაყრელი ",
                      Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ნერვიულობთ, მაგრამ იმედოვნებთ საუკეთესოს", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ფიქრობთ თქვენ მოქმედებებზე მოვლენათა ცუდად განვითარების შემთხვევაში", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თავს გრძნობთ სასიამოვნოდ, როცა ხართ საძინებელ ოთახში  და ელოდებით", Index = 2, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "ხდებით მეტად ფრთხილი, მაგრამ გჯერათ, რომ გაუმკლავდებით ნებისმიერ მოვლენას", Index =3 , Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ხდებით მეტად მოწადინებული, ელით უარესს", Index = 4, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ეს სიტუაცია თქვენ გახარებთ, ენგერგიას, სტიმულს გმატებთ", Index =5 , Points =  3
                      },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "მობილიზებას ახდენთ, მაგრამ არ გეშინიათ", Index = 6, Points = 4 }
                  }
                  },
                   new PsychometricQuestion
                   {
                       Body = "ჩაცმულობის მხრივ  თქვენ",
                       Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "არ მოგწონთ ექსტრავაგანტული სტილი და ცდილობთ არ გამოირჩეოდეთ", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "გირჩევით ელეგანტური და „მშვიდი“ სტილი", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "გირჩევნიათ ნათელი და ღია ფერის ტანსაცმელი, შემთხვევითი სტილი", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "ირჩევთ ხარისხიან, გამძლე საქონელს", Index =3 , Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "იცმევთ ისევე, როგორც სხვები", Index = 4, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "გირჩევნიათ „ხმამაღალი“, ზოგჯერ ექსტრავაგანტული სტილი", Index =5 , Points =  2
                      },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ხართ კმაყოფილი იმით, რაც გაქვთ, ნაკლებ ყურადღებას აქცევთ მოდას", Index = 6, Points = 3 }
                  }
                   },
                    new PsychometricQuestion
                    {
                        Body = "როგორც  წესი, თქვენ იწყებთ ინტიმურ ურთიერთობებს",
                        Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თუ იგი არ დამთავრდება ქორწინებით", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "იმ პარტიორთან, რომლის კულტურული, სოციალური და ინტელექტუალური დონე არ არის დაბალი თქვენთან შედარებით", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თუ თქვენ გაქვთ ძლიერი გრძნობები", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "იმ პარტნიორთან, რომელიც აღიარებს თქვენს უპირატესობას", Index =3 , Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თქვენ სულიერ მეგობართან", Index = 4, Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "მარტივად, შორს რომ არ იყურებით", Index =5 , Points =  1
                      },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "როდესაც თქვენი პარტნიორები არიან თქვენი თანმხლები პირები ზოგიერთ აქტივობაში", Index = 6, Points = 1 }
                  }
                    },
                     new PsychometricQuestion
                     {
                         Body = "როდესაც თქვენი უფლებები ირღვევა თქვენ",
                         Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "სავარაუდოთ ამ სიტუაციას ეგუებით", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "იმოქმედებთ ისევე, როგორც უმრავლესობა თქვენს ირგვლივ", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "შეხვალთ სასტიკ კონფლიქტში", Index = 2, Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "გაექცევით ასეთ სიტუაციებს", Index =3 , Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "დაამტკიცებთ თქვენ უფლებებს ნებისმიერ ფასად", Index = 4, Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "დაიცავთ მათ", Index =5 , Points =  2},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "უკომპრომისოდ დაამტკიცებთ მათ საერთო სამართლისთვის", Index = 6, Points = 2 }
                      }
                     },

                     new PsychometricQuestion
                     {
                         Body = "კონფლიქტები",
                         Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ ახერხებთ არ ჩაერთოთ მათში", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ იშვიათად აღმოჩდებით ხოლმე მათში ჩართული, მაგრამ თუ ასეა თავს დაიცავთ", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ ხშირად ხართ მათში ჩართული, თქვენივე ინიციატივით", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  " ხანდახან მოულოდნელად აღმოჩნდებით ჩართული მათში, მაგრამ ცდილობთ ეს დიდხანს არ გაგრძელდეს", Index =3 , Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ხშირად ხართ ჩართული, თუმცა თქვენ გარშემო მყოფნი არიან დამნაშავე", Index = 4, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " როცა თქვენ ხართ კონფლიქტში ჩართული, ცდილობთ მოაგვაროთ იგი", Index =5 , Points =  2},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ ცდილობთ მტრის დამარცხებას", Index = 6, Points = 3 }
                      }
                     },

                      new PsychometricQuestion
                      {
                          Body = "თქვენ ნერვიულობთ(განიცდით)",
                          Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ პროფესიულ შესაძლებლობებზე", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ ფინანსურ და სოციალურ სტატუსზე", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ სწრაფ და წარმატებულ წინსვლაზე", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  " თქვენ პერსონალურ წარმატებაზე", Index =3 , Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ პრესტიჯზე საზოგადოებაში", Index = 4, Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ პირად და სოციალურ სტატუსზე", Index =5 , Points =  2},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " კაცობრიობაზე", Index = 6, Points = 1 }
                      }
                      },

                       new PsychometricQuestion
                       {
                           Body = " თქვენ გირჩევნიათ იყოთ  ჩართული ისეთ რაღაცეებში, რაც",
                           Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " პირველ რიგში გაძლევთ მორალურ კმაყოფილებას", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " აუმჯობესებს თქვენი ცხოვრების დონეს", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " იწვევს თქვენში აღტკინების სურვილს და ვნებას", Index = 2, Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  " გაძლევთ საშუალებას ცხოვრებით დატკბეთ", Index =3 , Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " აძლიერებს თქვენ პრესტიჯს", Index = 4, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " გაძლევთ საშუალებას იცხოვროთ მიზანმიმართულად", Index =5 , Points =  2},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ძალიან მნიშვნელოვანია მთელი კაცობრიობისთვის", Index = 6, Points =1 }
                      }
                       },

                        new PsychometricQuestion
                        {
                            Body = "ოპონენტები(მოწინააღმდეგეები)",
                            Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ ხშირად უთმობთ მათ ", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ თავს არიდებთ მათ", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ ცდილობთ მათ განადგურებას", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  " დაჟინებით არწმუნებთ მათ თქვენ სისწორეში", Index =3 , Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ ებრძვით მათ", Index = 4, Points = 3},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " აქტიურობთ მათთან", Index =5 , Points =  2},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ მიდიხართ კომპრომისზე საჭიროების შემთხვევაში", Index = 6, Points = 1}
                      }
                        },

                         new PsychometricQuestion
                         {
                             Body = "თუ თქვენ  გაქვთ  საკმაოდ წარმატებული ცხოვრება, მაშინ",
                             Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თქვენ არ რისკავთ არსებულით, თუ არ იცით რომ მიაღწევთ უფრო მეტს", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თქვენ არ გსურთ რაიმე ცვლილებები", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "თქვენი მოქმედებები მიმართულია სხვისი ცხოვრების გასაუმჯობესებლად", Index = 2, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  " თქვენ მზად ხართ გარისკოთ უფრო დიდი წარმატებისთვის", Index =3 , Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " მიგაჩნიათ, რომ შეგეძლოთ უფრო მეტი მოგეპოვებინათ, მაგრამ არ გაგიმართლათ", Index = 4, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ ფიქრობთ, რომ ეს შეიძლება რადიკალურად შეიცვალოს არა კონკრეტული მიზეზით", Index =5 , Points =  2},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ ხართ კმაყოფილი, მაგრამ მუშაობთ განუწყვეტლივ გასაუმჯობესებლად მდგომარეობის", Index = 6, Points = 1 }
                      }
                         },

                          new PsychometricQuestion
                          {
                              Body = "როდესაც თქვენ იწყებთ მოქმედებას, მაშინ თქვენ",
                              Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ხშირად არ ხართ დარწმუნებული, რომ ეს მოქმედება სწორია", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თავს გრძნობთ უფრო თავდაჯერებულად, როდესაც სხვები გაამართლებენ თქვენ ქმედებებს", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ფიქრობთ, რომ ისინი ყველასთვის კარგია", Index = 2, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  " დარწმუნებული ხართ მათ სისწორეში, როდესაც სხვები მიიჩნევენ მათ არასწორ ქმედებებად", Index =3 , Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " სხვების გაფრთხილებები გაძლიერებენ, რომ მიჰყვეთ საკუთარ გზას(არჩევანს)", Index = 4, Points = 3 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ეს მოქმედებები ხანდახან შეიცავენ რისკებს, რათა შემოწმდეს თქვენი შესაძლებლობები, გამბედაობა და იღბალი", Index =5 , Points =  2},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ეყრდნობით უფრო თქვენ აზრს, ვიდრე სხვების", Index = 6, Points = 2 }
                      }
                          },

               new PsychometricQuestion
               {
                   Body = "თქვენი ყოველდღიური(რუტინული) მოვლენების დროს",
                   Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ხანდახან გინდებათ სრიულიად მარტო ყოფნა", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ძნელია, რომ მარტო დარჩეთ ", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ ზოგჯერ გაქვთ სურვილი, სადმე შორს წასვლის", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  " გჭირდებათ რადიკალური ცვლილებები ცხოვრებაში", Index =3 , Points = 32 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ხალხი ზოგჯერ გაღიზიანებთ", Index = 4, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ გწადიათ ძლიერი აღრფთოვანება(შფოთვა) და მღელვარება", Index =5 , Points =  3},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " თქვენ მუდმივად ჩართული ხართ ზოგ მნიშვნელოვან ამოცანაში", Index = 6, Points = 2 }
                      }
               },

               new PsychometricQuestion
               {
                   Body = "",
                   Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "", Index = 2, Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "", Index =3 , Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "", Index = 4, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "", Index =5 , Points =  2},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "", Index = 6, Points = 3 }
                      }
               },

               new PsychometricQuestion
               {
                   Body = "როდესაც ახორციელებთ ინვესტიციებს, თქვენ გირჩევნიათ",
                   Answers = new List<PsychometricQuestionPossibleAnswer> { 
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "მიიღოთ უსაფრთხო, შედარებით გრძელვადიანი(1 წელი ან მეტი) დეპოზიტი ოღონდ არა ძალიან მაღალი, მაგრამ ფიქსირებული საპროცენტოთი", Index = 0, Points = 0 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "მიიღოთ რეკომენდირებული დეპოზიტები ერთხმად და არა სერიოზული რისკით", Index = 1, Points =1  },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "მიიღოთ დეპოზიტები, რომლებსაც მოელით რომ არსებითად გაიზრდება პირველ ორ წელში", Index = 2, Points = 1 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText =  "ინვესტიციას დებთ ფინანსურ საწარმოში, რომელიც ბოლო პერიოდში სწრაფად ძლიერდება.ზოგჯერ თქვენ აძლევთ შეწირულობას საქველმოქმედო ფონდებსაც. ", Index =3 , Points = 2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "ინვესტიციას დებთ მნიშვნელოვანი თანხის მყარ საწარმოში ან ისეთ საწარმოში, რომლის მიმართაც გაქვთ პირადი ნდობა", Index = 4, Points =2 },
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = "შეიტანოთ თქვენი მთელი აქტივები გარიგებაში, რომელიც ფიქრობთ რომ მოიტანთ სწრაფ და მნიშვნელოვან ბრუნებას. ", Index =5 , Points = 3},
                      new PsychometricQuestionPossibleAnswer(){ AnswerText = " ინვესტირებას ახდენთ ისეთ ფონდებში, რომელთა მიზანია კაცობრიობის განვითარება და რომელშიც თქვენ იღებთ მონაწილეობას.", Index = 6, Points = 1 }
                      }
               }
            };

            var questionSet = context.Set<PsychometricQuestion>();

            foreach (var item in questions)
            {
                questionSet.Add(item);
            }

            base.Seed(context);
        }
    }
}
