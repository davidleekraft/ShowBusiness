namespace UnhandledExceptionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Garments",
                c => new
                    {
                        garment_ID = c.Int(nullable: false, identity: true),
                        costume_ID = c.String(),
                        main_category_ID = c.String(),
                        sub_category_ID = c.String(),
                        material_ID = c.String(),
                        pattern_ID = c.String(),
                        storage_ID = c.String(),
                        name = c.String(),
                        type = c.String(),
                        rented = c.Boolean(nullable: false),
                        rentable = c.Boolean(nullable: false),
                        photo = c.String(),
                        added_date = c.String(),
                        last_altered = c.String(),
                        last_cleaned_date = c.String(),
                        cleaning_instr = c.String(),
                    })
                .PrimaryKey(t => t.garment_ID);
            
            CreateTable(
                "dbo.Props",
                c => new
                    {
                        prop_ID = c.Int(nullable: false, identity: true),
                        main_category_ID = c.String(),
                        sub_category_ID = c.String(),
                        material_ID = c.String(),
                        storage_ID = c.String(),
                        name = c.String(),
                        rented = c.Boolean(nullable: false),
                        rentable = c.Boolean(nullable: false),
                        last_cleaned_date = c.String(),
                        cleaning_instr = c.String(),
                        description = c.String(),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.prop_ID);
            
            CreateTable(
                "dbo.Performers",
                c => new
                    {
                        performer_ID = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false),
                        last_name = c.String(),
                        phone = c.String(),
                        email = c.String(),
                        street_address = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zip = c.String(),
                        age = c.Int(nullable: false),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.performer_ID);
            
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        production_ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        start_date = c.String(),
                        end_date = c.String(),
                    })
                .PrimaryKey(t => t.production_ID);
            
            CreateTable(
                "dbo.Alterations",
                c => new
                    {
                        alteration_ID = c.Int(nullable: false, identity: true),
                        garment_ID = c.String(),
                        prop_ID = c.String(),
                        date_altered = c.String(nullable: false),
                        permanent = c.Boolean(nullable: false),
                        previous_state = c.String(nullable: false),
                        new_state = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.alteration_ID);
            
            CreateTable(
                "dbo.Damages",
                c => new
                    {
                        damage_ID = c.Int(nullable: false, identity: true),
                        garment_ID = c.String(),
                        prop_ID = c.String(),
                        date_damaged = c.DateTime(nullable: false),
                        exp_repair_date = c.DateTime(nullable: false),
                        repaired_date = c.DateTime(),
                        repair_desc = c.String(),
                    })
                .PrimaryKey(t => t.damage_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        category_ID = c.Int(nullable: false, identity: true),
                        category_title = c.String(),
                        category_desc = c.String(),
                        time_period = c.String(),
                    })
                .PrimaryKey(t => t.category_ID);
            
            CreateTable(
                "dbo.Costumes",
                c => new
                    {
                        costume_ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        creation_date = c.String(),
                        last_altered = c.String(),
                        num_pieces = c.Int(nullable: false),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.costume_ID);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        material_ID = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.material_ID);
            
            CreateTable(
                "dbo.Patterns",
                c => new
                    {
                        pattern_ID = c.Int(nullable: false, identity: true),
                        photo = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.pattern_ID);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        rental_ID = c.Int(nullable: false, identity: true),
                        renter_ID = c.String(),
                        prop_ID = c.String(),
                        garment_ID = c.String(),
                        date_taken = c.String(nullable: false),
                        date_returned = c.String(),
                        cond_returned = c.String(),
                        cost = c.String(nullable: false),
                        in_out = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.rental_ID);
            
            CreateTable(
                "dbo.Renters",
                c => new
                    {
                        renter_ID = c.Int(nullable: false, identity: true),
                        company_name = c.String(),
                        first_name = c.String(nullable: false),
                        last_name = c.String(nullable: false),
                        street_address = c.String(nullable: false),
                        city = c.String(nullable: false),
                        state = c.String(nullable: false),
                        zip = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        email = c.String(nullable: false),
                        renter_since = c.DateTime(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.renter_ID);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        size_ID = c.Int(nullable: false, identity: true),
                        type = c.String(nullable: false),
                        value = c.Int(nullable: false),
                        garment_ID = c.String(),
                        performer_ID = c.String(),
                        prop_ID = c.String(),
                    })
                .PrimaryKey(t => t.size_ID);
            
            CreateTable(
                "dbo.User_status",
                c => new
                    {
                        statusID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        privileges = c.String(),
                    })
                .PrimaryKey(t => t.statusID);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        storage_ID = c.Int(nullable: false, identity: true),
                        location_desc = c.String(),
                        environment = c.String(),
                        container = c.String(),
                        in_house = c.Boolean(nullable: false),
                        handling_instructions = c.String(),
                    })
                .PrimaryKey(t => t.storage_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        userName = c.String(nullable: false),
                        userPass = c.String(nullable: false),
                        firstName = c.String(nullable: false),
                        middleName = c.String(),
                        lastName = c.String(nullable: false),
                        streetAddress1 = c.String(),
                        streetAddress2 = c.String(),
                        apt = c.Int(),
                        city = c.String(),
                        state = c.String(),
                        zip = c.Int(),
                        zipExt = c.Int(),
                    })
                .PrimaryKey(t => t.userID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Storages");
            DropTable("dbo.User_status");
            DropTable("dbo.Sizes");
            DropTable("dbo.Renters");
            DropTable("dbo.Rentals");
            DropTable("dbo.Patterns");
            DropTable("dbo.Materials");
            DropTable("dbo.Costumes");
            DropTable("dbo.Categories");
            DropTable("dbo.Damages");
            DropTable("dbo.Alterations");
            DropTable("dbo.Productions");
            DropTable("dbo.Performers");
            DropTable("dbo.Props");
            DropTable("dbo.Garments");
        }
    }
}
